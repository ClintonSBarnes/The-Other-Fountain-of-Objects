using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal static class InputValidator
    {
        static int validatedBoardSize;

        public static int GetVaidatedSize()
        {
            return validatedBoardSize;
        }

        public static void SetValidatedSize(int size)
        {
            validatedBoardSize = size;
        }


        //input validators

        public static bool BoardSizeInputValidator(string input)
        {
            input = input.ToUpper();


            if (input != "E" && input != "A" && input != "X")
            {
                return false;
            }
            else if (input == "E")
            {
                SetValidatedSize(4);
                return true;
            }
            else if (input == "A")
            {
                SetValidatedSize(6);
                return true;
            }
            else SetValidatedSize(8);
            return true;
        }// (DONE) validates board size input 

        public static bool PlayerMoveInputValidation(Board board,Player player,string input)
        {
            input = input.ToUpper();

            if (input == "A") //***this is not an implemented function.***
            {
                Console.WriteLine("Which direction would you like to fire your arrow? " +
                    "(N)orth, (S)outh, (E)ast, or (W)est: ");
                return true;
            }
            if (input == "N")
            {
                player.SetPlayerLocation(board, player, (1,0));
                return true;
            }
            else if (input == "S")
            {
                player.SetPlayerLocation(board, player, (-1, 0));
                return true;
            }
            else if (input == "E")
            {
                player.SetPlayerLocation(board, player, (0, 1));
                return true;
            }
            else  if (input == "W")
            {
                player.SetPlayerLocation(board, player, (0, -1));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckFountainOn(Fountain fountain,string input)
        {
            input = input.ToUpper();

            if (input == "Y")
            {
                fountain.SetFountainOn(true);
                return true;
            }
            if (input == "N")
            {
                fountain.SetFountainOn(false);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
