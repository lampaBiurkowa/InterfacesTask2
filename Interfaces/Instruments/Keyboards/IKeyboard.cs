namespace DibryBand
{
    public interface IKeyboard : IInstrument
    {
        KeyboardTimbre PressKey(EmotionType emotion);
    }
}
