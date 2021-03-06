using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Maelstroms
    {
        public static (int, int)[] maelstroms = new (int, int)[8];
        static (int, int) _location;

        //*****only outward facing methods******
        public static void MaelstromsSetUp(int difficulty, Player player)
        {
            if (difficulty == 4)
            {
                MaelstromsGenerator(0, 4, player);
            }
            else if (difficulty == 6)
            {
                MaelstromsGenerator(1, 6, player);
            }
            else
            {
                MaelstromsGenerator(2, 8, player);
            }
        }
        public static (int, int) GetLocation()
        {
            return _location;
        }

        public static int GetMaelStromCount()
        {
            return maelstroms.Length;
        }
        public static (int, int)[] GetMaelstromArray()
        {
            return maelstroms;
        }

        //utility methods - protected for use only in this class.
        //builds and sets the location of the Amaroks randomly
        private static void MaelstromsGenerator(int Count, int size, Player player)
        {
            for (int i = 0; i < Count; i++)
            {
                EstablishMaelstroms(i, size, player);

            }
        }
        private static void EstablishMaelstroms(int maelstromArrayPosition, int size, Player player)
        {

            Random number = new Random();
            SetMaelstroms(size, maelstromArrayPosition, (number.Next(1, size), number.Next(1, size)), player);

        }

        private static void SetMaelstroms(int size, int maelstromArrayPosition, (int x, int y) location, Player player)
        {
            if (location != player.GetPlayerPosition())
            {
                maelstroms[maelstromArrayPosition] = (location);
            }
            else
            {
                EstablishMaelstroms(maelstromArrayPosition,size,player);
            }
        }
    }
}
