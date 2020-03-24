﻿using System;
using System.Collections.Generic;

namespace DibryBand
{
    public class ElectricGuitar : IGuitar
    {
        public int StringCount { get; private set; }

        public GuitarTimbre Jerk()
        {
            GuitarTimbre timbre = new GuitarTimbre();
            timbre.Dynamic = true;
            timbre.Loud = true;
            timbre.Synthetic = true;
            return timbre;
        }

        public void Play(IList<float> notes)
        {
            foreach (var note in notes)
                Console.WriteLine($"Playing {FrequencyMapper.GetNoteFromHz(note)} with timbre {Jerk().Emit()}");
        }
    }
}
