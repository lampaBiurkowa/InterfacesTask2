using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class BassVoice : IMaleVoice
    {
        public float MinFrequency => FrequencyMapper.GetHzFromNote("E2");
        public float MaxFrequency => FrequencyMapper.GetHzFromNote("B4");

        public VoiceTimbre EmitNormally(EmotionType emotion)
        {
            VoiceTimbre timbre = new VoiceTimbre();
            timbre.EmotionType = emotion;
            timbre.Loud = true;
            timbre.Harsh = false;
            timbre.Punchy = false;

            return timbre;
        }

        public VoiceTimbre EmitHarshly(EmotionType emotion)
        {
            VoiceTimbre timbre = new VoiceTimbre();
            timbre.EmotionType = emotion;
            timbre.Loud = true;
            timbre.Harsh = true;
            timbre.Punchy = false;

            return timbre;
        }

        public VoiceTimbre EmitFalsetto(EmotionType emotion)
        {
            VoiceTimbre timbre = new VoiceTimbre();
            timbre.EmotionType = emotion;
            timbre.Loud = false;
            timbre.Harsh = false;
            timbre.Punchy = false;

            return timbre;
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
                if (note >= FrequencyMapper.GetHzFromNote("G4") && (emotion == EmotionType.Subtle || emotion == EmotionType.Sad))
                    timbre = EmitFalsetto(emotion);
                else if (emotion == EmotionType.Aggressive || emotion == EmotionType.Sad)
                    timbre = EmitHarshly(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note)} with timbre {timbre.Emit()}");
            }
        }
    }
}
