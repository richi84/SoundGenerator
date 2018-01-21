using System;
using System.Reflection;

namespace SoundGenerator.Compose
{
    public static class Keyboard
    {
        public static float A0 { get { return a0; } }
        public static float Ais0 { get { return ais0; } }
        public static float H0 { get { return h0; } }
        public static float C1 { get { return c1; } }
        public static float Cis1 { get { return cis1; } }
        public static float D1 { get { return d1; } }
        public static float Dis1 { get { return dis1; } }
        public static float E1 { get { return e1; } }
        public static float F1 { get { return f1; } }
        public static float Fis1 { get { return fis1; } }
        public static float G1 { get { return g1; } }
        public static float Gis1 { get { return gis1; } }
        public static float A1 { get { return a1; } }
        public static float Ais1 { get { return ais1; } }
        public static float H1 { get { return h1; } }
        public static float C2 { get { return c2; } }
        public static float Cis2 { get { return cis2; } }
        public static float D2 { get { return d2; } }
        public static float Dis2 { get { return dis2; } }
        public static float E2 { get { return e2; } }
        public static float F2 { get { return f2; } }
        public static float Fis2 { get { return fis2; } }
        public static float G2 { get { return g2; } }
        public static float Gis2 { get { return gis2; } }
        public static float A2 { get { return a2; } }
        public static float Ais2 { get { return ais2; } }
        public static float H2 { get { return h2; } }
        public static float C3 { get { return c3; } }
        public static float Cis3 { get { return cis3; } }
        public static float D3 { get { return d3; } }
        public static float Dis3 { get { return dis3; } }
        public static float E3 { get { return e3; } }
        public static float F3 { get { return f3; } }
        public static float Fis3 { get { return fis3; } }
        public static float G3 { get { return g3; } }
        public static float Gis3 { get { return gis3; } }
        public static float A3 { get { return a3; } }
        public static float Ais3 { get { return ais3; } }
        public static float H3 { get { return h3; } }
        public static float C4 { get { return c4; } }
        public static float Cis4 { get { return cis4; } }
        public static float D4 { get { return d4; } }
        public static float Dis4 { get { return dis4; } }
        public static float E4 { get { return e4; } }
        public static float F4 { get { return f4; } }
        public static float Fis4 { get { return fis4; } }
        public static float G4 { get { return g4; } }
        public static float Gis4 { get { return gis4; } }
        public static float A4 { get { return a4; } }
        public static float Ais4 { get { return ais4; } }
        public static float H4 { get { return h4; } }
        public static float C5 { get { return c5; } }
        public static float Cis5 { get { return cis5; } }
        public static float D5 { get { return d5; } }
        public static float Dis5 { get { return dis5; } }
        public static float E5 { get { return e5; } }
        public static float F5 { get { return f5; } }
        public static float Fis5 { get { return fis5; } }
        public static float G5 { get { return g5; } }
        public static float Gis5 { get { return gis5; } }
        public static float A5 { get { return a5; } }
        public static float Ais5 { get { return ais5; } }
        public static float H5 { get { return h5; } }
        public static float C6 { get { return c6; } }
        public static float Cis6 { get { return cis6; } }
        public static float D6 { get { return d6; } }
        public static float Dis6 { get { return dis6; } }
        public static float E6 { get { return e6; } }
        public static float F6 { get { return f6; } }
        public static float Fis6 { get { return fis6; } }
        public static float G6 { get { return g6; } }
        public static float Gis6 { get { return gis6; } }
        public static float A6 { get { return a6; } }
        public static float Ais6 { get { return ais6; } }
        public static float H6 { get { return h6; } }
        public static float C7 { get { return c7; } }
        public static float Cis7 { get { return cis7; } }
        public static float D7 { get { return d7; } }
        public static float Dis7 { get { return dis7; } }
        public static float E7 { get { return e7; } }
        public static float F7 { get { return f7; } }
        public static float Fis7 { get { return fis7; } }
        public static float G7 { get { return g7; } }
        public static float Gis7 { get { return gis7; } }
        public static float A7 { get { return a7; } }
        public static float Ais7 { get { return ais7; } }
        public static float H7 { get { return h7; } }
        public static float C8 { get { return c8; } }

        static float a0 = 27.5f;
        static float ais0 = 29.1352f;
        static float h0 = 30.8677f;
        static float c1 = 32.7032f;
        static float cis1 = 34.6478f;
        static float d1 = 36.7081f;
        static float dis1 = 38.8909f;
        static float e1 = 41.2034f;
        static float f1 = 43.6535f;
        static float fis1 = 46.2493f;
        static float g1 = 48.9994f;
        static float gis1 = 51.9131f;
        static float a1 = 55f;
        static float ais1 = 58.2705f;
        static float h1 = 61.7354f;
        static float c2 = 65.4064f;
        static float cis2 = 69.2957f;
        static float d2 = 73.4162f;
        static float dis2 = 77.7817f;
        static float e2 = 82.4069f;
        static float f2 = 87.3071f;
        static float fis2 = 92.4986f;
        static float g2 = 97.9989f;
        static float gis2 = 103.826f;
        static float a2 = 110f;
        static float ais2 = 116.541f;
        static float h2 = 123.471f;
        static float c3 = 130.813f;
        static float cis3 = 138.591f;
        static float d3 = 146.832f;
        static float dis3 = 155.563f;
        static float e3 = 164.814f;
        static float f3 = 174.614f;
        static float fis3 = 184.997f;
        static float g3 = 195.998f;
        static float gis3 = 207.652f;
        static float a3 = 220f;
        static float ais3 = 233.082f;
        static float h3 = 246.942f;
        static float c4 = 261.626f;
        static float cis4 = 277.183f;
        static float d4 = 293.665f;
        static float dis4 = 311.127f;
        static float e4 = 329.628f;
        static float f4 = 349.228f;
        static float fis4 = 369.994f;
        static float g4 = 391.995f;
        static float gis4 = 415.305f;
        static float a4 = 440f;
        static float ais4 = 466.164f;
        static float h4 = 493.883f;
        static float c5 = 523.251f;
        static float cis5 = 554.365f;
        static float d5 = 587.33f;
        static float dis5 = 622.254f;
        static float e5 = 659.255f;
        static float f5 = 698.456f;
        static float fis5 = 739.989f;
        static float g5 = 783.991f;
        static float gis5 = 830.609f;
        static float a5 = 880f;
        static float ais5 = 932.328f;
        static float h5 = 987.767f;
        static float c6 = 1046.5f;
        static float cis6 = 1108.73f;
        static float d6 = 1174.66f;
        static float dis6 = 1244.51f;
        static float e6 = 1318.51f;
        static float f6 = 1396.91f;
        static float fis6 = 1479.98f;
        static float g6 = 1567.98f;
        static float gis6 = 1661.22f;
        static float a6 = 1760f;
        static float ais6 = 1864.66f;
        static float h6 = 1975.53f;
        static float c7 = 2093f;
        static float cis7 = 2217.46f;
        static float d7 = 2349.32f;
        static float dis7 = 2489.02f;
        static float e7 = 2637.02f;
        static float f7 = 2793.83f;
        static float fis7 = 2959.96f;
        static float g7 = 3135.96f;
        static float gis7 = 3322.44f;
        static float a7 = 3520f;
        static float ais7 = 3729.31f;
        static float h7 = 3951.07f;
        static float c8 = 4186.01f;

        static float[] noten;
        public static float[] NotenArray { get { return noten; } }

        static Keyboard()
        {
            PropertyInfo[] infos=typeof(Keyboard).GetProperties();
            noten=new float[88];

            int index = 0;
            foreach (PropertyInfo entry in infos)
            {
                if (entry.PropertyType == typeof(float))
                {
                    noten[index] = (float)entry.GetValue(null);
                    index++;
                }
            }
        }

        public static float GetFrequenzOfKey(int index)
        {
            return noten[index];
        }

        public static bool IsHalbton(int index)
        {
            switch ((index) % 12)
            {
                case 0: return false;   //A
                case 1: return true;    //Ais
                case 2: return false;   //H
                case 3: return false;   //C
                case 4: return true;    //Cis
                case 5: return false;   //D
                case 6: return true;    //Dis
                case 7: return false;   //E
                case 8: return false;   //F
                case 9: return true;    //Fis
                case 10: return false;  //G
                case 11: return true;   //Gis
            }

            throw new Exception("Error beim bestimmen vom Halbton!");
        }

        public static String GetName(int index)
        {
            switch ((index) % 12)
            {
                case 0: return "A";
                case 1: return "Ais";
                case 2: return "H";
                case 3: return "C";
                case 4: return "Cis";
                case 5: return "D";
                case 6: return "Dis";
                case 7: return "E";
                case 8: return "F";
                case 9: return "Fis";
                case 10: return "G";
                case 11: return "Gis";
            }

            throw new Exception("Error beim bestimmen vom Halbton!");
        }

        public static int GetNumberOfNoten()
        {
            return 88;
        }

        public static int GetGrundtonOffset(KeyType tonart)
        {
            if((int)tonart<15)
            {
                return (74 - ((int)tonart) * 5) % 12;
            }

            return (71 - ((int)tonart-15) * 5) % 12;
        }
    }
}
