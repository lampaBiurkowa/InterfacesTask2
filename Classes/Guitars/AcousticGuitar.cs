using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class AcousticGuitar : IGuitar
    {
        public int StringCount { get; private set; }

        public GuitarTimbre Jerk()
        {
            return new GuitarTimbre
            {
                Dynamic = true,
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
