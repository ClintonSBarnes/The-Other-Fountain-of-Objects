using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal static class Dialogue
    {
        static string output;
        static string fountainOff = "You hear water dripping in this room. The Fountain of Objects is here!";
        static string fountainOn = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
        static string pitNear = "You feel a draft. There is a pit in a nearby room.";
        static string maelstromNear = "You hear the growling and groaning of a maelstrom nearby.";
        static string amarokNear = "You can smell the rotten stench of an amarok in a nearby room.";
        static string atEntrance = "You see light coming from the cavern entrance.";


        public static void Difficulty(Board board)
        {
            string thisUserInput = "no input";

            while (InputValidator.BoardSizeInputValidator(thisUserInput) == false)
            {
                Console.WriteLine("Please select a level of difficutly. (E)asy, (A)dvanced, or e(X)pert: ");
                thisUserInput = Console.ReadLine();
                if (InputValidator.BoardSizeInputValidator(thisUserInput) == true)
                {
                    board.SetSize(InputValidator.GetVaidatedSize());
                }
            }
        }

        public static void IntroductionPhrase()
        {
            PrintBreakLine();
            Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountains." +
            "\nLight is visible only in the entrance, and no other light is seen anywhere in the caverns." +
            "\nYou must navigate the Caverns with your other senses." +
            "\nFind the Fountains of Objects, activate it, and return to the entrance.");
            PrintBreakLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PlayerMoveMenu(Board board, Player player, Fountain fountain)
        {
            bool validTest = false;
            string input;

            while (validTest == false)
            {
                Console.WriteLine("Where would you like to move? (N)orth, (S)outh, (E)ast, or (W)est: ");

                input = Console.ReadLine();
                //***If arrows are going to be implemented, this is the where the input will occur.***
                validTest = InputValidator.PlayerMoveInputValidation(board, player, input);
                if (validTest == false)
                {
                    validTest = InputValidator.PlayerMoveInputValidation(board, player, input);
                    Console.WriteLine("That was not a valid input. Please try again.");
                }
                board.BoardUpdater(player);
                Console.Clear();
            }
            board.BoardUpdater(player);
            Dialogue.RoomStatus(board, player, fountain);


        }

        public static void HelpMenu()
        {

        }

        public static void RoomStatus(Board board, Player player, Fountain fountain)
        {
            PrintBreakLine();
            board.RoomDetailsBuilder(board, player.GetPlayerPosition(), fountain);//***************current to do.
            board.BoardUpdater(player);//not sure about this location for this fuction.
            Console.WriteLine($"You are in the room at (Row={board.GetPlayerPosition().Item1}, Column={board.GetPlayerPosition().Item2})");
            if (player.GetArrowCount() >0)
            {
                Console.WriteLine($"You currently have {player.GetArrowCount()} arrows.");
            }
            if (board.pitNear == true)
            {
                Console.WriteLine(pitNear);
            }
            if (board.amarokNear == true)
            {
                Console.WriteLine(amarokNear);
            }
            if (board.maelstromNear == true)
            {
                Console.WriteLine(maelstromNear);
            }
            if (board.amarokPresent == true || board.pitPresent == true)
            {
                if (board.pitPresent == true)
                {
                    Console.WriteLine("Well, boss...it looks like you have found your self in a 'you're dead' type of situation. \n" +
                        "You fell in a pit. I'm just saying that you are dead now. Sorry, bruh.\nPress something to move on.");
                    player.SetPlayerAlive(false);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Dude, remember when I told you about those Amaroks?..Well, there is one in this room,...and now you're dead. Sucks for you, guy.\nPress something to move on.");
                    player.SetPlayerAlive(false);

                }


            }
            if (board.maelstromsPresent == true)
            {
                player.SetPlayerLocation(board,player, (+1,+2));
            }

            if (fountain.GetFountainLocation == player.GetPlayerPosition && fountain.GetFountainOn() == false)
            {
                string fountainInput;
                bool inputValidation = false;
                while (inputValidation == false)
                {
                    Console.WriteLine(fountainOff);
                    Console.WriteLine("Would you like to turn the fountian on? (Y)es or (N)o: ");
                    fountainInput = Console.ReadLine();
                    inputValidation = InputValidator.CheckFountainOn(fountain, fountainInput);
                    if (inputValidation == false)
                    {
                        Console.WriteLine("That was not a valid input. Please try again.");
                    }
                    else
                    {
                        inputValidation = true;
                    }
                }

            }
            if (fountain.GetFountainLocation == player.GetPlayerPosition && fountain.GetFountainOn() == true)
            {
                Console.WriteLine(fountainOn);
            }
            if (player.GetPlayerAlive() == true)
            {
                Console.WriteLine("What do you want to do?");

                PlayerMoveMenu(board, player, fountain);
            }
            else if (player.GetPlayerAlive() == false)
            {
                Console.WriteLine("\n---------" +
                                  "\n| x   x |" +
                                  "\n|   U   |" +
                                  "\n|  xxx  |" +
                                  "\n---------");

            }

        }
        public static void PrintBreakLine()
        {
            Console.WriteLine("\n**********************************************************************************************************************\n");
        }
    }
}
