using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Xml.Linq;

namespace poetts
{
    public partial class Gui : Form
    {
        private readonly SpeechSynthesizer _speechSynthesizer;

        private readonly List<string> _poeXmlStrings = [];

        private Configuration _config;

        private const int ControlKeyModifier = 2;
        private const int WmHotkey = 0x0312;
        private const string GameProcessName = "PillarsOfEternity";

        private int _filesLoaded;
        private int _stringsLoaded;
        private int _ocrAttempts;
        private int _ttsAttempts;
        private bool _isTtsPaused;

        private string _settingHkeyExtract = "E";
        private string _settingHkeyKeyRead = "R";
        private string _settingHkeyKeyPause = "P";
        private string _settingHkeyKeyStop = "S";

        private string _settingPoeGamePath = "";

        // will never be null
        private readonly string _settingPoettsPath = Path.GetDirectoryName(Application.ExecutablePath)!;


        // #region App logic

        /// <summary>
        /// Setup custom hotkeys and stuff .. for future use, prolly.
        /// </summary>
        private void LoadAppConfig()
        {
            _settingHkeyExtract = _config.AppSettings.Settings["hkey_extract"].Value;
            _settingHkeyKeyRead = _config.AppSettings.Settings["hkey_read"].Value;
            _settingHkeyKeyPause = _config.AppSettings.Settings["hkey_pause"].Value;
            _settingHkeyKeyStop = _config.AppSettings.Settings["hkey_stop"].Value;
            _settingPoeGamePath = GetPoeInstallationPath();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WmHotkey)
            {
                var id = m.WParam.ToInt32();

                HandleHotKeys(id);
            }

            base.WndProc(ref m);
        }

        private void RegisterHotKeys()
        {
            User32.RegisterHotKey(Handle, 1, ControlKeyModifier, _settingHkeyExtract[0]);
            User32.RegisterHotKey(Handle, 2, ControlKeyModifier, _settingHkeyKeyRead[0]);
            User32.RegisterHotKey(Handle, 3, ControlKeyModifier, _settingHkeyKeyPause[0]);
            User32.RegisterHotKey(Handle, 4, ControlKeyModifier, _settingHkeyKeyStop[0]);
        }

        private void HandleHotKeys(int id)
        {
            switch (id)
            {
                // Extract
                case 1:
                    OcrExtractText();

                    SearchMatch(textOcr.Text);
                    break;
                // Read
                case 2:
                    TtsSpeak();
                    break;
                // Pause
                case 3:
                    TtsPause();
                    break;
                // Stop
                case 4:
                    TtsStop();
                    break;
            }
        }

        //////////////////////////////////////
        /// OCR
        /////////////////////////////////////////////////
        private void CaptureScreenShot(Process gameProcess)
        {
            UpdateStatusBar("Capturing screen..");

            var rect = new User32.Rect();
            User32.GetWindowRect(gameProcess.MainWindowHandle, ref rect);

            var width = rect.right - rect.left;
            var height = rect.bottom - rect.top;

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(
                rect.left,
                rect.top,
                0,
                0,
                new Size(width, height),
                CopyPixelOperation.SourceCopy
            );

            bmp.Save($@"{_settingPoettsPath}\temp\x.png", ImageFormat.Png);
        }

        private string GetTextFromBitmap()
        {
            ProcessStartInfo info = new(
                $@"{_settingPoettsPath}\tesseract\tesseract.exe",
                $@"{_settingPoettsPath}\temp\x.png {_settingPoettsPath}\temp\x -l eng {_settingPoettsPath}\tesseract\char_whitelist")
            {
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process? p = Process.Start(info);
            p?.WaitForExit();

            using var tr = new StreamReader($@"{_settingPoettsPath}\temp\x.txt");
            var res = tr.ReadToEnd();

            return res.Trim();
        }

        private void OcrExtractText()
        {
            textOcr.Text = "";
            textMatch.Text = "";

            Process? gameProcess = Process.GetProcessesByName(GameProcessName).FirstOrDefault();

            if (gameProcess == null)
            {
                MessageBox.Show(
                    "Cannot find Pillars of Eternity process, make sure the game is running and try again.",
                    "Cannot find game process",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            CaptureScreenShot(gameProcess);

            UpdateStatusBar("Tesseract processing..");

            textOcr.Text = GetTextFromBitmap().Replace("\n", Environment.NewLine);

            _ocrAttempts++;
        }

        /// <summary>
        /// I think I should patent this algorithm
        /// </summary>
        private string SearchMatch(string ocrText)
        {
            if (string.IsNullOrEmpty(_settingPoeGamePath))
            {
                textMatch.Text = "Pillars of Eternity installation folder was not found.";

                return ocrText;
            }

            UpdateStatusBar("Searching for matches..");

            var words = ocrText.Split([",", ";", ".", "!", "?", " "], StringSplitOptions.RemoveEmptyEntries);

            var bestMatch = "";
            var bestMatchCounts = 0;
            var currentMatchCounts = 0;

            foreach (var entry in _poeXmlStrings)
            {
                currentMatchCounts += words.Count(word => word.Length > 3 && entry.Contains(word));

                if (currentMatchCounts > bestMatchCounts)
                {
                    bestMatchCounts = currentMatchCounts;
                    bestMatch = entry;
                }

                currentMatchCounts = 0;
            }

            textMatch.Text = "(" + bestMatchCounts + ") " + bestMatch.Replace("\n", Environment.NewLine);

            UpdateStatusBar("Match found.");

            return bestMatch;
        }

        //////////////////////////////////////
        /// Text to speech
        /////////////////////////////////////////////////
        private void TtsSpeak()
        {
            TtsStop();

            OcrExtractText();

            if (string.IsNullOrEmpty(textOcr.Text))
            {
                textOcr.Text = "No text found.";

                TtsSpeakAsync(textOcr.Text);
            }
            else
            {
                var bestMatch = SearchMatch(textOcr.Text);

                TtsSpeakAsync(bestMatch);
            }

            _ttsAttempts++;
        }

        private void TtsSpeakAsync(string data)
        {
            try
            {
                _speechSynthesizer.Rate = trackBarRate.Value;
                _speechSynthesizer.Volume = trackBarVolume.Value;
                _speechSynthesizer.SelectVoice(comboBoxVoices.Text);

                _speechSynthesizer.SpeakAsync(data);

                UpdateStatusBar("Playing text to speech..");
            }
            catch (Exception ex)
            {
                UpdateStatusBar("Text to speech error!");

                MessageBox.Show(ex.Message);
            }
        }

        private void TtsPause()
        {
            if (_isTtsPaused)
            {
                _speechSynthesizer.Resume();

                _isTtsPaused = false;

                button2.Text = "Pause (Ctrl+P)";

                UpdateStatusBar("Playing text to speech..");
            }
            else
            {
                _speechSynthesizer.Pause();

                _isTtsPaused = true;

                button2.Text = "Resume (Ctrl+P)";

                UpdateStatusBar("Text to speech paused.");
            }
        }

        private void TtsStop()
        {
            _speechSynthesizer.SpeakAsyncCancelAll();

            UpdateStatusBar("Text to speech stopped.");
        }

        private string GetPoeInstallationPath()
        {
            var path = ConfigurationManager.AppSettings["poe_game_path"] ?? "";

            if (!string.IsNullOrEmpty(path)) return path;

            DialogResult result = MessageBox.Show(
                "Pillars of Eternity game path not found. " +
                "You may still use Poetts, however the program may not work as expected. " +
                "Would you like to select it now?",
                "Poetts - Game not found", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                var folderDialog = new FolderBrowserDialog();
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderDialog.SelectedPath;
                    _config.AppSettings.Settings.Add("poe_game_path", path);
                }
            }

            return path;
        }

        //////////////////////////////////////
        /// Buttons and stuff
        /////////////////////////////////////////////////
        public Gui()
        {
            _speechSynthesizer = new SpeechSynthesizer();
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            InitializeComponent();

            MaximizeBox = false;

            textOcr.Multiline = true;
            textOcr.ScrollBars = ScrollBars.Vertical;
            textOcr.AcceptsReturn = true;
            textOcr.AcceptsTab = true;
            textOcr.WordWrap = true;

            textMatch.Multiline = true;
            textMatch.ScrollBars = ScrollBars.Vertical;
            textMatch.AcceptsReturn = true;
            textMatch.AcceptsTab = true;
            textMatch.WordWrap = true;

            Console.WriteLine("Starting..");

            LoadAppConfig();

            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            RegisterHotKeys();

            UpdateStatusBar("Loading POE XML files..");

            if (!string.IsNullOrEmpty(_settingPoeGamePath))
            {
                LoadXmlFiles(".stringtable", $@"{_settingPoeGamePath}\PillarsOfEternity_Data\data\localized\en\");
            }

            UpdateStatusBar("Ready.");
        }

        private void LoadXmlFiles(string fileType, string dir)
        {
            try
            {
                foreach (var f in Directory.GetFiles(dir))
                {
                    if (f.Contains(fileType))
                    {
                        XDocument xml = XDocument.Load(f);

                        var query = from c in xml.Root?.Descendants("Entry")
                            select c.Element("DefaultText")?.Value;

                        foreach (var defaultText in query)
                        {
                            _poeXmlStrings.Add(defaultText);

                            _stringsLoaded++;
                        }
                    }

                    _filesLoaded++;

                    UpdateStatusBar("Loading POE XML files..");
                }

                foreach (var d in Directory.GetDirectories(dir))
                {
                    LoadXmlFiles(fileType, d);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStatusBar(string status)
        {
            toolStripStatusFiles.Text = "Files: " + _filesLoaded;
            toolStripStatusStrings.Text = "Strings: " + _stringsLoaded;
            toolStripStatusOCR.Text = "OCR: " + _ocrAttempts;
            toolStripStatusTTS.Text = "TTS: " + _ttsAttempts;
            toolStripStatusApp.Text = status;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  _speechSynthesizer = new SpeechSynthesizer();

            foreach (InstalledVoice voice in _speechSynthesizer.GetInstalledVoices())
            {
                comboBoxVoices.Items.Add(voice.VoiceInfo.Name);
            }

            comboBoxVoices.SelectedIndex = 0; // 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TtsSpeak();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TtsPause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TtsStop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OcrExtractText();

            SearchMatch(textOcr.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented.", "Poetts - Parameters");
        }
    }
}
