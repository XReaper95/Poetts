using System.Collections;
using System.Reflection;
using System.Speech.Synthesis;

namespace SpeechApiFix
{
// https://stackoverflow.com/questions/51811901/speechsynthesizer-doesnt-get-all-installed-voices-3
    public static class SpeechApiReflectionHelper
    {
        private const string PropVoiceSynthesizer = "VoiceSynthesizer";
        private const string FieldInstalledVoices = "_installedVoices";

        private const string OneCoreVoicesRegistry = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices";

        public static void InjectOneCoreVoices(this SpeechSynthesizer synthesizer)
        {
            var voiceSynthesizer = GetProperty(synthesizer, PropVoiceSynthesizer);
            if (voiceSynthesizer == null)
                throw new NotSupportedException($"Property not found: {PropVoiceSynthesizer}");

            if (GetField(voiceSynthesizer, FieldInstalledVoices) is not IList installedVoices)
                throw new NotSupportedException($"Field not found or null: {FieldInstalledVoices}");

            if (ObjectTokenCategoryType
                    .GetMethod("Create", BindingFlags.Static | BindingFlags.NonPublic)?
                    .Invoke(null, [OneCoreVoicesRegistry]) is not IDisposable otc)
                throw new NotSupportedException($"Failed to call Create on {ObjectTokenCategoryType} instance");

            using (otc)
            {
                if (ObjectTokenCategoryType
                        .GetMethod("FindMatchingTokens", BindingFlags.Instance | BindingFlags.NonPublic)?
                        .Invoke(otc, [null, null]) is not IList tokens)
                    throw new NotSupportedException($"Failed to list matching tokens");

                // to remove duplicated voices
                installedVoices.Clear();

                foreach (var token in tokens)
                {
                    if (token == null || GetProperty(token, "Attributes") == null) continue;

                    var voiceInfo =
                        typeof(SpeechSynthesizer).Assembly
                            .CreateInstance(VoiceInfoType.FullName!, true,
                                BindingFlags.Instance | BindingFlags.NonPublic, null,
                                new object[] { token }, null, null);

                    if (voiceInfo == null)
                        throw new NotSupportedException($"Failed to instantiate {VoiceInfoType}");

                    var installedVoice =
                        typeof(SpeechSynthesizer).Assembly
                            .CreateInstance(InstalledVoiceType.FullName!, true,
                                BindingFlags.Instance | BindingFlags.NonPublic, null,
                                [voiceSynthesizer, voiceInfo], null, null);

                    if (installedVoice == null)
                        throw new NotSupportedException($"Failed to instantiate {InstalledVoiceType}");

                    installedVoices.Add(installedVoice);
                }
            }
        }

        private static readonly Type ObjectTokenCategoryType = typeof(SpeechSynthesizer).Assembly
            .GetType("System.Speech.Internal.ObjectTokens.ObjectTokenCategory")!;

        private static readonly Type VoiceInfoType = typeof(SpeechSynthesizer).Assembly
            .GetType("System.Speech.Synthesis.VoiceInfo")!;

        private static readonly Type InstalledVoiceType = typeof(SpeechSynthesizer).Assembly
            .GetType("System.Speech.Synthesis.InstalledVoice")!;

        private static object? GetProperty(object target, string propName)
        {
            return target.GetType().GetProperty(propName, BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(target);
        }

        private static object? GetField(object target, string propName)
        {
            return target.GetType().GetField(propName, BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(target);
        }
    }
}
