using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Player
    {
         (int, int) playerLocation;
        bool playerAlive = true;



        public void InitialPlayerLocation()
        {
            playerLocation = (0, 0);
        }

        public (int,int) GetPlayerPosition()
        {
            return playerLocation;
        }

        public bool GetPlayerAlive()
        {
            return playerAlive;
        }
        public void SetPlayerAlive(bool alive)
        {
            if (alive == true)
            {
                playerAlive = true;
            }
            else
            {
                playerAlive = false;
            }
        }

        public void SetPlayerLocation(Board board,Player player, (int x,int y) input)
        {
            if (player.playerLocation.Item1 + input.x <= board.GetSize() && player.playerLocation.Item2 + input.y <= board.GetSize() && player.playerLocation.Item1 + input.x > -1 && player.playerLocation.Item1 + input.y > -1)
            {
                player.playerLocation = (player.playerLocation.Item1 + input.x, player.playerLocation.Item2 + input.y);
            }
            else
            {
                Console.WriteLine("That would be a move beyond the wall, so it is NOT POSSIBLE. Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
