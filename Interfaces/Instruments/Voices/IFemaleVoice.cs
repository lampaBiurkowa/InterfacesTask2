namespace DibryBand
{
    public interface IFemaleVoice : IVoice
    {
        VoiceTimbre EmitScream(EmotionType emotion);
    }
}
