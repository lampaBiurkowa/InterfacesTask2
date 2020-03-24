namespace DibryBand
{
    public class VoiceTimbre : ITimbre
    {
        public EmotionType EmotionType { get; set; }
        public bool Harsh { get; set; }
        public bool Loud { get; set; }
        public bool Punchy { get; set; }

        public string Emit()
        {
            string volume = Loud ? "loudly" : "quietly";
            string punchy = Punchy ? "punchy" : "";
            string harsh = Harsh ? "harshly" : "";
            return $" singed {EmotionType} {volume} {punchy} {harsh}";
        }
    }
}
