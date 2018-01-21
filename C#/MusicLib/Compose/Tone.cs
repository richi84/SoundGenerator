using SoundGenerator.Wave;

namespace SoundGenerator.Compose
{
    public partial class Tone
    {
        private double fromTime;
        public double FromTime
        {
            get { return fromTime; }
            set
            {
                fromTime = value;
            }
        }

        private double toTime;
        public double ToTime
        {
            get { return toTime; }
            set
            {
                toTime = value;
            }
        }

        private int keyNumber;
        public int KeyNumber
        {
            get { return keyNumber; }
            set
            {
                keyNumber = value;
            }
        }

        public IInstrument Instrument { set; get; }

        public Tone(double pFrom, double pTo, int pKeyNumber, IInstrument pInstrument)
        {
            FromTime = pFrom;
            ToTime = pTo;
            KeyNumber = pKeyNumber;
            Instrument = pInstrument;
        }
    }
}
