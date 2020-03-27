using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class BassGuitar : IGuitar
    {
        public int StringCount { get; private set; }

        public GuitarTimbre Jerk()
        {
            return new GuitarTimbre
            {
                Dynamic = false,
                Loud = false,
                Synthetic = false
            };
        }

        public void Play(IList<float> notes)
        {
            foreach (var note in notes)
                Console.WriteLine($"Playing {FrequencyMapper.Instance.GetNoteFromHz(note)} with timbre {Jerk().Emit()}");
        }
    }
}