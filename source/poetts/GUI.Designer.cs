using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace poetts
{
    partial class Gui
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Gui));
            groupBox1 = new GroupBox();
            textOcrOutput = new TextBox();
            label8 = new Label();
            comboBoxLanguage = new ComboBox();
            label7 = new Label();
            label5 = new Label();
            textMatch = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            trackBarRate = new TrackBar();
            trackBarVolume = new TrackBar();
            comboBoxVoices = new ComboBox();
            textOcr = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            save_button = new Button();
            extract_button = new Button();
            parameters_button = new Button();
            read_button = new Button();
            pause_button = new Button();
            stop_button = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusFiles = new ToolStripStatusLabel();
            toolStripStatusStrings = new ToolStripStatusLabel();
            toolStripStatusOCR = new ToolStripStatusLabel();
            toolStripStatusTTS = new ToolStripStatusLabel();
            toolStripStatusApp = new ToolStripStatusLabel();
            groupBox3 = new GroupBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)trackBarRate).BeginInit();
            ((ISupportInitialize)trackBarVolume).BeginInit();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            //
            // groupBox1
            //
            groupBox1.Controls.Add(textOcrOutput);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(comboBoxLanguage);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textMatch);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(trackBarRate);
            groupBox1.Controls.Add(trackBarVolume);
            groupBox1.Controls.Add(comboBoxVoices);
            groupBox1.Controls.Add(textOcr);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 104);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1122, 497);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Text To Speech";
            //
            // textOcrOutput
            //
            textOcrOutput.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textOcrOutput.Location = new Point(769, 43);
            textOcrOutput.Multiline = true;
            textOcrOutput.Name = "textOcrOutput";
            textOcrOutput.Size = new Size(333, 246);
            textOcrOutput.TabIndex = 24;
            textOcrOutput.Text = "Empty";
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Font = new Font("Century", 9F);
            label8.Location = new Point(769, 22);
            label8.Name = "label8";
            label8.Size = new Size(164, 18);
            label8.TabIndex = 23;
            label8.Text = "OCR command output";
            //
            // comboBoxLanguage
            //
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Location = new Point(9, 324);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new Size(1081, 26);
            comboBoxLanguage.TabIndex = 22;
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(7, 303);
            label7.Name = "label7";
            label7.Size = new Size(152, 18);
            label7.TabIndex = 21;
            label7.Text = "TTS\\OCR Language";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(9, 159);
            label5.Name = "label5";
            label5.Size = new Size(155, 18);
            label5.TabIndex = 20;
            label5.Text = "Best matching string";
            //
            // textMatch
            //
            textMatch.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textMatch.Location = new Point(9, 180);
            textMatch.Multiline = true;
            textMatch.Name = "textMatch";
            textMatch.Size = new Size(737, 109);
            textMatch.TabIndex = 19;
            textMatch.Text = "No match found.";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(9, 353);
            label4.Name = "label4";
            label4.Size = new Size(47, 18);
            label4.TabIndex = 17;
            label4.Text = "Voice";
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(818, 414);
            label3.Name = "label3";
            label3.Size = new Size(51, 18);
            label3.TabIndex = 16;
            label3.Text = "Speed";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(235, 414);
            label2.Name = "label2";
            label2.Size = new Size(62, 18);
            label2.TabIndex = 15;
            label2.Text = "Volume";
            //
            // trackBarRate
            //
            trackBarRate.LargeChange = 2;
            trackBarRate.Location = new Point(551, 435);
            trackBarRate.Name = "trackBarRate";
            trackBarRate.Size = new Size(537, 56);
            trackBarRate.TabIndex = 14;
            trackBarRate.Value = 1;
            //
            // trackBarVolume
            //
            trackBarVolume.LargeChange = 10;
            trackBarVolume.Location = new Point(0, 435);
            trackBarVolume.Maximum = 100;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(541, 56);
            trackBarVolume.SmallChange = 5;
            trackBarVolume.TabIndex = 13;
            trackBarVolume.Value = 90;
            //
            // comboBoxVoices
            //
            comboBoxVoices.FormattingEnabled = true;
            comboBoxVoices.Location = new Point(9, 374);
            comboBoxVoices.Name = "comboBoxVoices";
            comboBoxVoices.Size = new Size(1081, 26);
            comboBoxVoices.TabIndex = 12;
            //
            // textOcr
            //
            textOcr.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textOcr.Location = new Point(7, 43);
            textOcr.Multiline = true;
            textOcr.Name = "textOcr";
            textOcr.Size = new Size(739, 109);
            textOcr.TabIndex = 7;
            textOcr.Text = "No text found.";
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Century", 9F);
            label1.Location = new Point(9, 22);
            label1.Name = "label1";
            label1.Size = new Size(110, 18);
            label1.TabIndex = 6;
            label1.Text = "Extracted text";
            //
            // groupBox2
            //
            groupBox2.Controls.Add(save_button);
            groupBox2.Controls.Add(extract_button);
            groupBox2.Controls.Add(parameters_button);
            groupBox2.Controls.Add(read_button);
            groupBox2.Controls.Add(pause_button);
            groupBox2.Controls.Add(stop_button);
            groupBox2.Location = new Point(12, 607);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1122, 77);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Options";
            //
            // save_button
            //
            save_button.Location = new Point(925, 23);
            save_button.Name = "save_button";
            save_button.Size = new Size(165, 37);
            save_button.TabIndex = 5;
            save_button.Text = "Save Config";
            save_button.UseVisualStyleBackColor = true;
            save_button.Click += save_button_Click;
            //
            // extract_button
            //
            extract_button.Location = new Point(9, 26);
            extract_button.Name = "extract_button";
            extract_button.Size = new Size(165, 36);
            extract_button.TabIndex = 4;
            extract_button.Text = "Extract (Ctrl+E)";
            extract_button.UseVisualStyleBackColor = true;
            extract_button.Click += extract_button_Click;
            //
            // parameters_button
            //
            parameters_button.Enabled = false;
            parameters_button.Location = new Point(742, 23);
            parameters_button.Name = "parameters_button";
            parameters_button.Size = new Size(165, 37);
            parameters_button.TabIndex = 3;
            parameters_button.Text = "Parameters";
            parameters_button.UseVisualStyleBackColor = true;
            parameters_button.Click += parameters_button_Click;
            //
            // read_button
            //
            read_button.Location = new Point(191, 26);
            read_button.Name = "read_button";
            read_button.Size = new Size(165, 36);
            read_button.TabIndex = 0;
            read_button.Text = "Read (Ctrl+R)";
            read_button.UseVisualStyleBackColor = true;
            read_button.Click += read_button_Click;
            //
            // pause_button
            //
            pause_button.Location = new Point(376, 25);
            pause_button.Name = "pause_button";
            pause_button.Size = new Size(165, 37);
            pause_button.TabIndex = 1;
            pause_button.Text = "Pause (Ctrl+P)";
            pause_button.UseVisualStyleBackColor = true;
            pause_button.Click += pause_button_Click;
            //
            // stop_button
            //
            stop_button.Location = new Point(560, 23);
            stop_button.Name = "stop_button";
            stop_button.Size = new Size(165, 37);
            stop_button.TabIndex = 2;
            stop_button.Text = "Stop (Ctrl+S)";
            stop_button.UseVisualStyleBackColor = true;
            stop_button.Click += stop_button_Click;
            //
            // statusStrip1
            //
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusFiles, toolStripStatusStrings, toolStripStatusOCR, toolStripStatusTTS, toolStripStatusApp });
            statusStrip1.Location = new Point(0, 691);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1145, 26);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            //
            // toolStripStatusLabel1
            //
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(128, 20);
            toolStripStatusLabel1.Text = "Language: English";
            //
            // toolStripStatusFiles
            //
            toolStripStatusFiles.Name = "toolStripStatusFiles";
            toolStripStatusFiles.Size = new Size(53, 20);
            toolStripStatusFiles.Text = "Files: 0";
            //
            // toolStripStatusStrings
            //
            toolStripStatusStrings.Name = "toolStripStatusStrings";
            toolStripStatusStrings.Size = new Size(69, 20);
            toolStripStatusStrings.Text = "Strings: 0";
            //
            // toolStripStatusOCR
            //
            toolStripStatusOCR.Name = "toolStripStatusOCR";
            toolStripStatusOCR.Size = new Size(53, 20);
            toolStripStatusOCR.Text = "OCR: 0";
            //
            // toolStripStatusTTS
            //
            toolStripStatusTTS.Name = "toolStripStatusTTS";
            toolStripStatusTTS.Size = new Size(48, 20);
            toolStripStatusTTS.Text = "TTS: 0";
            //
            // toolStripStatusApp
            //
            toolStripStatusApp.Name = "toolStripStatusApp";
            toolStripStatusApp.Size = new Size(116, 20);
            toolStripStatusApp.Text = "Status: Loading..";
            //
            // groupBox3
            //
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(12, 13);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1122, 85);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Quick Help";
            //
            // label6
            //
            label6.Location = new Point(7, 26);
            label6.Name = "label6";
            label6.Size = new Size(1109, 54);
            label6.TabIndex = 0;
            label6.Text = resources.GetString("label6.Text");
            //
            // Gui
            //
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 717);
            Controls.Add(groupBox3);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Gui";
            Text = "Poe·tts — Pillars of Eternity Text to Speech";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)trackBarRate).EndInit();
            ((ISupportInitialize)trackBarVolume).EndInit();
            groupBox2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textOcr;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TrackBar trackBarRate;
        private TrackBar trackBarVolume;
        private ComboBox comboBoxVoices;
        private GroupBox groupBox2;
        private Button read_button;
        private Button stop_button;
        private Button pause_button;
        private Button parameters_button;
        private Button extract_button;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusApp;
        private ToolStripStatusLabel toolStripStatusFiles;
        private ToolStripStatusLabel toolStripStatusStrings;
        private ToolStripStatusLabel toolStripStatusOCR;
        private ToolStripStatusLabel toolStripStatusTTS;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label5;
        private TextBox textMatch;
        private GroupBox groupBox3;
        private Label label6;
        private Label label7;
        private ComboBox comboBoxLanguage;
        private Button save_button;
        private Label label8;
        private TextBox textOcrOutput;
    }
}

