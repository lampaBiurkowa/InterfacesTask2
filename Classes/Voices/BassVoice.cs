using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class BassVoice : IMaleVoice
    {
        public float MinFrequency => FrequencyMapper.Instance.GetHzFromNote("E2");
        public float MaxFrequency => FrequencyMapper.Instance.GetHzFromNote("B4");

        public VoiceTimbre EmitNormally(EmotionType emotion)
        {
            return new VoiceTimbre
            {
                EmotionType = emotion,
                Loud = true,
                Harsh = false,
                Punchy = false
            };
        }

        public VoiceTimbre EmitHarshly(EmotionType emotion)
        {
            return new VoiceTimbre
            {
                EmotionType = emotion,
                Loud = true,
                Harsh = true,
                Punchy = false
            };
        }

        public VoiceTimbre EmitFalsetto(EmotionType emotion)
        {
            return new VoiceTimbre
            {
                EmotionType = emotion,
                Loud = false,
                Harsh = false,
                Punchy = false
            };
        }

        public void Play(IList<float> notes)
        {
            Random random = new Random();
            foreach (var note in notes)
            {
                if (note > MaxFrequency || note < MinFrequency)
                {
                    Console.WriteLine("I can't sing it!");
                    continue;
                }

                VoiceTimbre timbre;
                EmotionType emotion = (EmotionType)random.Next(0, 3);
                if (note >= FrequencyMapper.Instance.GetHzFromNote("G4") && (emotion == EmotionType.Subtle || emotion == EmotionType.Sad))
                    timbre = EmitFalsetto(emotion);
                else if (emotion == EmotionType.Aggressive || emotion == EmotionType.Sad)
                    timbre = EmitHarshly(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.Instance.GetNoteFromHz(note)} with timbre {timbre.Emit()}");
            }
        }
    }
}
