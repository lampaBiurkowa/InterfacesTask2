using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class Organ : IKeyboard
    {
        public KeyboardTimbre PressKey(EmotionType emotion)
        {
            return new KeyboardTimbre
            {
                Dynamic = true,
                EmotionType = emotion,
                Loud = false
            };
        }

        public void Play(IList<float> notes)
        {
            Random random = new Random();
            foreach (var note in notes)
            {
                EmotionType emotion = (EmotionType)random.Next(0, 3);
                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note)} with timbre {PressKey(emotion).Emit()}");
            }
        }
    }
}
