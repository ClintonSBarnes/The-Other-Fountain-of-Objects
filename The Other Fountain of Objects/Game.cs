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
                Dialogue.RoomStatus(board,player,fountain);

            }

        }






        public  bool GetStillPlaying()
        { return _stillPlaying;}

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
            Pit.PitSetUp(board.GetSize());
            Amarok.AmarokSetUp(board.GetSize());
            Maelstroms.MaelstromsSetUp(board.GetSize());
            fountain.EstablishFountain(board.GetSize());            
        }
        public GameState GetGameState()
        { return _currentState; }

        public void StartGame()
        {
            Dialogue.IntroductionPhrase();//shows welcome text that explains the game.
            Dialogue.Difficulty(board); //collects user input for difficutly level
            SetGameState(); //establishes game state for beginning 
            board.BoardBuilder(InputValidator.GetVaidatedSize());
            AdvasaryCreator();
            player.InitialPlayerLocation();
        }


    }
}
enum GameState { playing, win, lose, }
