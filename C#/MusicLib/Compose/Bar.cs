namespace SoundGenerator.Compose
{
    public class Bar
    {
        public KeyType KeyType { set; get; }

        public Bar(KeyType keyType)
        {
            KeyType = keyType;
        }

        public int NrInGruppe { get; internal set; }
        public int Stufe { get; set; }
    }
}