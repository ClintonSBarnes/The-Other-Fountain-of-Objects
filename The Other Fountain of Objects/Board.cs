using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Other_Fountain_of_Objects
{
    internal class Board
    {
        int _size;
        int[,] coordinates4 = new int[4, 4];
        int[,] coordinates6 = new int[6, 6];
        int[,] coordinates8 = new int[8, 8];
        int[,] coordinates;

        (int, int)[] pits;
        (int, int)[] amaroks;
        (int, int)[] maelstroms;

        int pitCount;
        int amarokCount;
        int maelstromsCount;

        public bool pitPresent = false;
        public bool amarokPresent = false;
        public bool maelstromsPresent = false;
        public bool fountianPresent = false;


        public bool pitNear = false;
        public bool amarokNear = false;
        public bool maelstromNear = false;


        (int, int) playerPosition;



        public void RoomDetailsBuilder(Board board, (int, int) playerLocation, Fountain fountain)
        {
            (int, int) coordToCheckAgainst = (0, 0);
            maelstromsPresent = false;
            amarokPresent = false;
            pitPresent = false;
            fountianPresent = false;
            maelstromNear = false;
            amarokNear = false;
            pitNear = false;
            

            for (int k = 0; k < board.GetSize(); k++)
            {


                for (int i = 0; i < board.GetSize(); i++)
                {
                    for (int j = 0; j < board.GetSize(); j++)
                    {
                        coordToCheckAgainst = (i, j);

                        if (coordToCheckAgainst == maelstroms[k] && coordToCheckAgainst == playerPosition && maelstroms[k] != (0, 0))
                        {
                            maelstromsPresent = true;
                        }
                        
                        if (coordToCheckAgainst == amaroks[k] && coordToCheckAgainst == playerPosition && amaroks[k] != (0, 0))
                        {
                            amarokPresent = true;
                        }
                        
                        if (coordToCheckAgainst == pits[k] && coordToCheckAgainst == playerPosition && pits[k] != (0, 0))
                        {
                            pitPresent = true;
                        }
                       

                        if (coordToCheckAgainst == fountain.GetFountainLocation())
                        {
                            board.fountianPresent = true;
                        }
                       
                    }
                }


                for (int i = 0; i < board.GetSize(); i++)
                {
                    for (int j = 0; j < board.GetSize(); j++)
                    {
                        coordToCheckAgainst = (i , j);

                        if  ((coordToCheckAgainst == maelstroms[k] && (coordToCheckAgainst.Item1+1, coordToCheckAgainst.Item2) == playerPosition && maelstroms[k] != (0, 0))
                            ||(coordToCheckAgainst == maelstroms[k] && (coordToCheckAgainst.Item1, coordToCheckAgainst.Item2 + 1) == playerPosition && maelstroms[k] != (0, 0))
                            ||(coordToCheckAgainst == maelstroms[k] && (coordToCheckAgainst.Item1+1, coordToCheckAgainst.Item2 + 1) == playerPosition && maelstroms[k] != (0, 0))
                            ||(coordToCheckAgainst == maelstroms[k] && (coordToCheckAgainst.Item1 -1, coordToCheckAgainst.Item2 ) == playerPosition && maelstroms[k] != (0, 0))
                            ||(coordToCheckAgainst == maelstroms[k] && (coordToCheckAgainst.Item1, coordToCheckAgainst.Item2 - 1) == playerPosition && maelstroms[k] != (0, 0))
                            ||(coordToCheckAgainst == maelstroms[k] && (coordToCheckAgainst.Item1-1, coordToCheckAgainst.Item2 - 1) == playerPosition && maelstroms[k] != (0, 0)))
                        {
                            maelstromNear = true;
                        }
                        
                        if  ((coordToCheckAgainst == amaroks[k] && (coordToCheckAgainst.Item1 + 1, coordToCheckAgainst.Item2) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == amaroks[k] && (coordToCheckAgainst.Item1, coordToCheckAgainst.Item2 + 1) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == amaroks[k] && (coordToCheckAgainst.Item1 + 1, coordToCheckAgainst.Item2 + 1) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == amaroks[k] && (coordToCheckAgainst.Item1 - 1, coordToCheckAgainst.Item2) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == amaroks[k] && (coordToCheckAgainst.Item1, coordToCheckAgainst.Item2 - 1) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == amaroks[k] && (coordToCheckAgainst.Item1 - 1, coordToCheckAgainst.Item2 - 1) == playerPosition && maelstroms[k] != (0, 0)))
                        {
                            amarokNear = true;
                        }
                       
                        if  ((coordToCheckAgainst == pits[k] && (coordToCheckAgainst.Item1 + 1, coordToCheckAgainst.Item2) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == pits[k] && (coordToCheckAgainst.Item1, coordToCheckAgainst.Item2 + 1) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == pits[k] && (coordToCheckAgainst.Item1 + 1, coordToCheckAgainst.Item2 + 1) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == pits[k] && (coordToCheckAgainst.Item1 - 1, coordToCheckAgainst.Item2) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == pits[k] && (coordToCheckAgainst.Item1, coordToCheckAgainst.Item2 - 1) == playerPosition && maelstroms[k] != (0, 0))
                            || (coordToCheckAgainst == pits[k] && (coordToCheckAgainst.Item1 - 1, coordToCheckAgainst.Item2 - 1) == playerPosition && maelstroms[k] != (0, 0)))
                        {
                            pitNear = true;
                        }
                        
                    }
                }

            }
        }
        public void BoardUpdater(Player player)
        {
            pitCount = Pit.GetPitCount();
            amarokCount = Amarok.GetAmarokCount();
            maelstromsCount = Maelstroms.GetMaelStromCount();
            pits = Pit.GetPitsArray();
            amaroks = Amarok.GetAmarokArray();
            maelstroms = Maelstroms.GetMaelstromArray();
            playerPosition = player.GetPlayerPosition();
        }

        public (int, int) GetPlayerPosition()
        {
            return playerPosition;
        }


        public int GetSize()
        {
            return _size;
        }
        public void SetSize(int size) //need a feeder method from the input validation class.
        {
            _size = size;
        }

        public void BoardBuilder(int size)
        {
            if (size == 4)
            {
                _size = size;
                coordinates = coordinates4;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        coordinates[i, j] = j;
                    }

                }
            }
            else if (size == 6)
            {
                _size = size;
                coordinates = coordinates6;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        coordinates[i, j] = j;
                    }

                }
            }

            else
            {
                _size = size;
                coordinates = coordinates8;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        coordinates[i, j] = j;
                    }

                }
            }
        }
    }
}


