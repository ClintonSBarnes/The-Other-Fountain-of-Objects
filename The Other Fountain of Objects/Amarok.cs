using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Amarok
    {
        public static (int, int)[] amaroks = new (int, int)[8];

        //*****only outward facing methods******
        public static void AmarokSetUp(int difficulty, Player player)
        {
            if (difficulty == 4)
            {
                AmarokGenerator(0, 4, player);
            }
            else if (difficulty == 6)
            {
                AmarokGenerator(2, 6, player);
            }
            else
            {
                AmarokGenerator(3, 8, player);
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
        private static void AmarokGenerator(int Count, int size, Player player)
        {
            for (int i = 0; i < Count; i++)
            {
                EstablishAmarok(i, size, player);
            }
        }
        private static void EstablishAmarok(int amaroksArrayPosition, int size, Player player)
        {

            Random number = new Random();
            SetAmarok(size, amaroksArrayPosition, (number.Next(1, size), number.Next(1, size)), player);

        }

        private static void SetAmarok(int size, int amarokArrayPosition, (int x, int y) location, Player player)
        {
            if (location != player.GetPlayerPosition())
            {
                amaroks[amarokArrayPosition] = (location);
            }
            else
            {
                EstablishAmarok(amarokArrayPosition, size, player);
            }
        }
    }
}
