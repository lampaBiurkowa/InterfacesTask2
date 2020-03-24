namespace DibryBand
{
    public interface IVoice : IInstrument
    {
        float MaxFrequency { get; }
        float MinFrequency { get; }

        VoiceTimbre EmitNormally(EmotionType emotion);
    }
}
