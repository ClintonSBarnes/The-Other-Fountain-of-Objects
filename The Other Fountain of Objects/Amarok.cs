using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Amarok
    {
        public static (int, int)[] amaroks = new (int, int)[3];

        //*****only outward facing methods******
        public static void AmarokSetUp(int difficulty)
        {
            if (difficulty == 4)
            {
                AmarokGenerator(0, 4);
            }
            else if (difficulty == 6)
            {
                AmarokGenerator(2, 6);
            }
            else
            {
                AmarokGenerator(3, 8);
            }
        }
        public static (int, int) GetLocation(int amarokArrayPosition)
        {
            return amaroks[amarokArrayPosition];
        }

        public static int GetAmarokCount()
        {
            return amaroks.Length;
        }
        public static (int, int)[] GetAmarokArray()
        {
            return amaroks;
        }

        //utility methods - protected for use only in this class.
        //builds and sets the location of the Amarok randomly
        private static void AmarokGenerator(int Count, int size)
        {
            for (int i = 0; i < Count; i++)
            {
                EstablishAmarok(i, size);
            }
        }
        private static void EstablishAmarok(int amaroksArrayPosition, int size)
        {

            Random number = new Random();
            SetAmarok(amaroksArrayPosition, (number.Next(1, size), number.Next(1, size)));

        }

        private static void SetAmarok(int amarokArrayPosition, (int x, int y) location)
        {
            amaroks[amarokArrayPosition] = (location);
        }
    }
}
