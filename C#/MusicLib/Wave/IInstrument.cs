namespace SoundGenerator.Wave
{
    public interface IInstrument
    {
        float CalcValue(float v, float t, float f);
    }
}
