namespace DibryBand
{
    public interface IMaleVoice : IVoice
    {
        VoiceTimbre EmitHarshly(EmotionType emotion);
        VoiceTimbre EmitFalsetto(EmotionType emotion);
    }
}
