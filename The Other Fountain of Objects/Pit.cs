using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Pit
    {
        
        public static (int, int)[] pits = new (int, int)[8];

        //*****only outward facing methods******
        public static void PitSetUp(int difficulty, Player player)
        {
            if (difficulty == 4)
            {
                PitGenerator(1, 4, player);
            }
            else if (difficulty == 6)
            {
                PitGenerator(2, 6, player);
            }
            else
            {
                PitGenerator(4, 8, player);
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
        private static void PitGenerator(int Count, int size, Player player)
        {
            for (int i = 0; i < Count; i++)
            {                
                EstablishPit(i, size, player);
            }
        }
        private static void EstablishPit(int pitArrayPosition,int size, Player player)
        {

            Random number = new Random();
            SetPit(size,pitArrayPosition,(number.Next(1, size), number.Next(1, size)), player);

        }

        private static void SetPit(int size,int pitArrayPosition,(int x, int y) location, Player player)
        {
            if (location != player.GetPlayerPosition())
            {
                pits[pitArrayPosition] = (location);
            }
            else EstablishPit(pitArrayPosition, size, player);
        }
    }
}
