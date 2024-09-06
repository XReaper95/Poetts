using System.Runtime.Versioning;
using System.Speech.Synthesis;
using SpeechApiFix;

// only works on windows
[assembly: SupportedOSPlatform("windows")]

namespace SampleSynthesis
{
    internal static class Program
    {
        private static void Main()
        {
            // Initialize a new instance of the SpeechSynthesizer.
            using (SpeechSynthesizer synth = new())
            {
                synth.InjectOneCoreVoices(); // fix microsoft API bug

                var installedVoices = synth.GetInstalledVoices();

                // Output information about all the installed voices.
                Console.WriteLine("Installed voices -");
                foreach (InstalledVoice voice in installedVoices)
                {
                    VoiceInfo info = voice.VoiceInfo;
                    var audioFormats = info.SupportedAudioFormats.Aggregate("", (current, fmt) => current + $"{fmt.EncodingFormat.ToString()}\n");

                    Console.WriteLine(" Name:          " + info.Name);
                    Console.WriteLine(" Culture:       " + info.Culture);
                    Console.WriteLine(" Age:           " + info.Age);
                    Console.WriteLine(" Gender:        " + info.Gender);
                    Console.WriteLine(" Description:   " + info.Description);
                    Console.WriteLine(" ID:            " + info.Id);
                    Console.WriteLine(" Enabled:       " + voice.Enabled);
                    if (info.SupportedAudioFormats.Count != 0)
                    {
                        Console.WriteLine(" Audio formats: " + audioFormats);
                    }
                    else
                    {
                        Console.WriteLine(" No supported audio formats found");
                    }

                    var additionalInfo = info.AdditionalInfo.Keys.Aggregate("", (current, key) => current +
                        $"  {key}: {info.AdditionalInfo[key]}\n");

                    Console.WriteLine(" Additional Info - " + additionalInfo);
                    Console.WriteLine();
                }

                Console.WriteLine("Summary: ");
                Console.WriteLine("Voices found: " + installedVoices.Count);
                foreach (InstalledVoice voice in installedVoices)
                {
                    VoiceInfo info = voice.VoiceInfo;
                    Console.WriteLine($" - {info.Name} {info.Culture.Name}");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
