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
        int arrowCount;


        public int GetArrowCount()
        {
            return arrowCount;
        }
        public void ArrowCreator(int difficulty)
        {
            if (difficulty == 6)
            {
                arrowCount = 6;
            }
            if (difficulty == 8)
            {
                arrowCount = 12;
            }
        }
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

        public void SetPlayerLocation(Board board,Player player, (int x,int y) input) //(DONE)
        {
            if (input == (+1,+2) && player.playerLocation.Item1 + input.x <= board.GetSize() && input.y <= board.GetSize())
            {
                player.playerLocation.Item1 = input.x;
                player.playerLocation.Item2 = input.y;
               
            }
            if (input == (+1,+2) && player.playerLocation.Item1 + input.x > board.GetSize())
            {
                player.playerLocation.Item1 = 0+input.x;
            }
            if (input == (+1,+2) &&  input.y > board.GetSize())
            {
                player.playerLocation.Item2 = 0+input.y;
            }
            if (player.playerLocation.Item1 + input.x <= board.GetSize() && player.playerLocation.Item2 + input.y <= board.GetSize() && player.playerLocation.Item1 + input.x > -1 && player.playerLocation.Item2 + input.y > -1)
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
