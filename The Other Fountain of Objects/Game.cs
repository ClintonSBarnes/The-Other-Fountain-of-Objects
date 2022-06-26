using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Game
    {
        private bool _stillPlaying = true;
        private GameState _currentState;
        public Board board = new Board();
        Player player = new Player();
        Fountain fountain = new Fountain();

        public (int, int)[] maelstroms = new (int, int)[2];



        //RUN - This is the method that handles the program.
        public void Run()
        {

            StartGame(); //this method sets up the initial game state.

            while (GetGameState() == GameState.playing)
            {
                Dialogue.RoomStatus(board, player, fountain);
                if (EndLoss(player.GetPlayerAlive()) == false)
                {
                    break;
                }
                if (player.GetPlayerAlive() == true && player.GetPlayerPosition() == (0, 0) && fountain.GetFountainOn() == true)
                {
                    Console.WriteLine("You are a real winner. Way to be, chief.");
                    break;
                }
                

            }



        }






        public bool GetStillPlaying()
        { return _stillPlaying; }

        public void SetGameState() // uses current board and player states to determine if the GameState.
        {
            board.BoardUpdater(player);

            if (player.GetPlayerAlive() == true && fountain.GetFountainOn() == true && player.GetPlayerPosition() == (0, 0))
            {
                _currentState = GameState.win;

            }
            else if (player.GetPlayerAlive() == false)
            {
                _currentState = GameState.lose;
            }
            else
            {
                _currentState = GameState.playing;
            }


        }

        public void AdvasaryCreator()
        {
            Pit.PitSetUp(board.GetSize(), player);
            Amarok.AmarokSetUp(board.GetSize(), player);
            Maelstroms.MaelstromsSetUp(board.GetSize(), player);
            fountain.EstablishFountain(board.GetSize(), player);
        }
        public GameState GetGameState()
        { return _currentState; }

        public void StartGame()
        {
            Dialogue.IntroductionPhrase();//shows welcome text that explains the game.
            Dialogue.Difficulty(board); //collects user input for difficutly level
            SetGameState(); //establishes game state for beginning 
            board.BoardBuilder(InputValidator.GetVaidatedSize());//builds array of coordinates reprsenting the board.
            player.InitialPlayerLocation();//places the player at the start/end location.
            AdvasaryCreator(); //generates advasaries in the quantity appropriate for the board size, and it places them randomly.

        }

        public static bool EndLoss(bool loss)
        {
            if (loss = false)
            {
                Console.WriteLine("You have died. All is lost. You are a failure!");
                return loss;
            }
            else
            {
                return loss;
            }
        }
    }
}
enum GameState { playing, win, lose, }
