using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Pit
    {
        
        public static (int, int)[] pits = new (int, int)[4];

        //*****only outward facing methods******
        public static void PitSetUp(int difficulty)
        {
            if (difficulty == 4)
            {
                PitGenerator(1, 4);
            }
            else if (difficulty == 6)
            {
                PitGenerator(2, 6);
            }
            else
            {
                PitGenerator(4, 8);
            }
        }
        public (int, int) GetLocation(int pitArrayPosition)
        {
            return pits[pitArrayPosition];
        }

        public static int GetPitCount()
        {
            return pits.Length;
        }

        public static (int, int)[] GetPitsArray()
        {
            return pits;
        }

        //utility methods - protected for use only in this class.
        //builds and sets the location of the Pit randomly
        private static void PitGenerator(int Count, int size)
        {
            for (int i = 0; i < Count; i++)
            {                
                EstablishPit(i, size);
            }
        }
        private static void EstablishPit(int pitArrayPosition,int size)
        {

            Random number = new Random();
            SetPit(pitArrayPosition,(number.Next(1, size), number.Next(1, size)));

        }

        private static void SetPit(int pitArrayPosition,(int x, int y) location)
        {
            pits[pitArrayPosition] = (location);
        }
    }
}
