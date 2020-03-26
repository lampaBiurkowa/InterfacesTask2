using System.Collections.Generic;

namespace DibryBand
{
    class Program
    {
        static void Main(string[] args)
        {
            AcousticGuitar acousticGuitar = new AcousticGuitar();
            BassGuitar bassGuitar = new BassGuitar();
            ElectricGuitar electricGuitar = new ElectricGuitar();
            Organ organ = new Organ();
            Piano piano = new Piano();
            AltoVoice alto = new AltoVoice();
            BassVoice bass = new BassVoice();
            SopranoVoice soprano = new SopranoVoice();
            TenorVoice tenor = new TenorVoice();

            List<IInstrument> instruments = new List<IInstrument>();
            instruments.Add(acousticGuitar);
            instruments.Add(bassGuitar);
            instruments.Add(electricGuitar);
            instruments.Add(organ);
            instruments.Add(piano);
            instruments.Add(alto);
            instruments.Add(bass);
            instruments.Add(soprano);
            instruments.Add(tenor);

            List<float> notes = new List<float>();
            notes.Add(FrequencyMapper.GetHzFromNote("C3"));
            notes.Add(FrequencyMapper.GetHzFromNote("D3"));
            notes.Add(FrequencyMapper.GetHzFromNote("E3"));
            notes.Add(FrequencyMapper.GetHzFromNote("F3"));
            notes.Add(FrequencyMapper.GetHzFromNote("G3"));
            notes.Add(FrequencyMapper.GetHzFromNote("A3"));
            notes.Add(FrequencyMapper.GetHzFromNote("B3"));
            notes.Add(FrequencyMapper.GetHzFromNote("C4"));

            foreach (var i in instruments)
                i.Play(notes);

            Performer performer1 = new Performer(new AcousticGuitar(), new BassVoice());
            performer1.PlayGuitar(notes);
            Performer performer2 = new Performer(new ElectricGuitar(), new AltoVoice());
            performer2.Sing(notes);
        }
    }
}
