using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Maelstroms
    {
        public static(int, int)[] maelstroms = new (int, int)[3];
        static (int, int) _location;

        //*****only outward facing methods******
        public static void MaelstromsSetUp(int difficulty)
        {
            if (difficulty == 4)
            {
                MaelstromsGenerator(0, 4);
            }
            else if (difficulty == 6)
            {
                MaelstromsGenerator(1, 6);
            }
            else
            {
                MaelstromsGenerator(2, 8);
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
        private static void MaelstromsGenerator(int Count, int size)
        {
            for (int i = 0; i < Count; i++)
            {
                new Pit();
                EstablishMaelstroms(size);

            }
        }
        private static void EstablishMaelstroms(int size)
        {

            Random number = new Random();
            SetMaelstroms((number.Next(1, size), number.Next(1, size)));

        }

        private static void SetMaelstroms((int x, int y) location)
        {
            _location = (location);
        }
    }
}
