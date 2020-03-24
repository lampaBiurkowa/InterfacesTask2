﻿using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class BassVoice : IMaleVoice
    {
        public float MaxFrequency => FrequencyMapper.GetHzFromNote("E2");
        public float MinFrequency => FrequencyMapper.GetHzFromNote("B4");

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

        public void Play(IList<INote> notes)
        {
            Random random = new Random();
            foreach (var note in notes)
            {
                VoiceTimbre timbre;
                EmotionType emotion = (EmotionType)random.Next(0, 3);
                if (note.Frequency >= FrequencyMapper.GetHzFromNote("G4") && (emotion == EmotionType.Subtle || emotion == EmotionType.Sad))
                    timbre = EmitFalsetto(emotion);
                else if (emotion == EmotionType.Aggressive || emotion == EmotionType.Sad)
                    timbre = EmitHarshly(emotion);
                else
                    timbre = EmitNormally(emotion);

                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note.Frequency)} with timbre {timbre.Emit()}");
            }
        }
    }
}