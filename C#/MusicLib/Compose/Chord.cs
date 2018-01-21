using System;

namespace SoundGenerator.Compose
{
    public static class ChordHelper
    {
        public static int GetStufenOffset(bool dur, int scaleStep)
        {
            if(dur)
            {
                switch(scaleStep)
                {
                    case 1: return 0;
                    case 2: return 2;
                    case 3: return 4;
                    case 4: return 5;
                    case 5: return 7;
                    case 6: return 9;
                    case 7: return 11;
                }
            }
            else
            {
                switch (scaleStep)
                {
                    case 1: return 0;
                    case 2: return 2;
                    case 3: return 3;
                    case 4: return 5;
                    case 5: return 7;
                    case 6: return 8;
                    case 7: return 10;
                }
            }

            throw new Exception("Scale step not found");
        }

        public static ToneSequence GetScaleStepChordTyp(bool isMajor, int scaleStep)
        {
            if (isMajor)
            {
                switch (scaleStep)
                {
                    case 1: return ToneSequence.MajorTriad;
                    case 2: return ToneSequence.MinerTriad;
                    case 3: return ToneSequence.MinerTriad;
                    case 4: return ToneSequence.MajorTriad;
                    case 5: return ToneSequence.MajorTriad;
                    case 6: return ToneSequence.MinerTriad;
                    case 7: return ToneSequence.Major7thChord;
                }
            }
            else
            {
                switch (scaleStep)
                {
                    case 1: return ToneSequence.MinerTriad;
                    case 2: return ToneSequence.MinerTriad;
                    case 3: return ToneSequence.MajorTriad;
                    case 4: return ToneSequence.MinerTriad;
                    case 5: return ToneSequence.MajorTriad;
                    case 6: return ToneSequence.MajorTriad;
                    case 7: return ToneSequence.MajorTriad;
                }
            }

            throw new Exception("Scale step not found");
        }

        public static int[] DurTriad()
        {
            return new int[]
                        {
                            0,
                            4,
                            7 
                        };
        }

        public static int[] MollTriad()
        {
            return new int[]
                        {
                            0,
                            3,  
                            7  
                        };
        }

        public static int[] Major7thTriad()
        {
            return new int[]
                        {
                            0,
                            4, 
                            7,
                            10  
                        };
        }

        public static int[] Pentatonic(bool dur)
        {
            if (dur)
            {
                return new int[]
                            {
                                0,
                                2,
                                4,
                                7,
                                9
                            };
            }
            else
            {
                return new int[]
                            {
                                0,
                                3,
                                5,
                                7,
                                10
                            };
            }
        }

        public static int[] BluesScale()
        {
            return new int[]
                        {
                            0,
                            3,
                            5,
                            6,
                            7,
                            10
                        };
        }
    }


}
