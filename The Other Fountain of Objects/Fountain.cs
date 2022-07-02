using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Fountain
    {
         bool fountainOn;
         bool fountainInRoom;
         (int x, int y) fountainLocation;

        public  bool GetFountainOn()
        {
            return fountainOn;
        }

        public void SetFountainOn(bool changer)
        {
            if (changer == true)
            {
                fountainOn = true;
            }
            else
            {
                fountainOn = false;
            }
        }
        public  bool IsFoutainNear((int x,int y) player)
        {
            if (player == fountainLocation)
            {
                return true;
            }
            else return false;
        }

        public  void EstablishFountain(int size, Player player)
        {
            fountainOn = false;
            Random number = new Random();
            SetFountain(size, (number.Next(number.Next(1, size)), number.Next(number.Next(1,size))), player);
            
        }

        public  void SetFountain(int size, (int x, int y) location, Player player)
        {
            if (location != player.GetPlayerPosition())
            {
                fountainLocation = (location);
            }
            else
            {
                EstablishFountain(size, player);
            }
        }

        public (int,int)  GetFountainLocation()
        {
            return fountainLocation;
        }
    }
}
