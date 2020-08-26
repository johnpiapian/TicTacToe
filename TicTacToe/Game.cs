using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        Player playerX;
        Player playerY;
        Board gameBoard;
        string[] gameArray = new string[9];
        string gamePlayer;

        public void PlayAgain()
        {
            string response;

            DisplayWelcome();


            do
            {
                Console.Clear();
                Play();
                Console.Write("\n\nWould you like to play again? (Y or N) ");
                response = Console.ReadLine().ToUpper();

                //Fix substring error
                if (response.Length > 0)
                {
                    response = response.Substring(0, 1);
                }
                else
                {
                    response = "N";
                }
            }
            while (response == "Y");
        }

        public void DisplayWelcome()
        {
            Console.WriteLine("\n\n\nReady to have a rousing game of Tic Tac toe?  The object");
            Console.WriteLine("of the game is to get three of your pieces either across, up and down,");
            Console.WriteLine("or diagonally.  If you do, before your opponent, you win the game!");
            Console.WriteLine("\n\nHit any key when you are ready to begin");
            Console.ReadKey();
            Console.Clear();
        }

        public void Play()
        {
            bool result = false;
            bool tieGame = false;
            int selection;

            playerX = new HumanPlayer();
            playerY = new ComputerPlayer();
            gameBoard = new Board();

            for (int index = 0; index < gameArray.Length; index++)
                gameArray[index] = " ";
            gamePlayer = "X";

            DisplayBoardGrid();

            do
            {

                //selection = IsPlaying(gamePlayer);
                if (gamePlayer == "X")
                {
                    selection = IsPlaying(gamePlayer);
                }
                else
                {
                    //add AI here

                    selection = -1; //requires a default value for DisplayGrid() to function

                    int YhasNext = gameBoard.hasWinningMove(playerY, playerX);
                    int XhasNext = gameBoard.hasWinningMove(playerX, playerY);

                    if (YhasNext > -1)
                    {
                        selection = YhasNext;
                        playerY.MakeMove(selection);
                        Console.WriteLine(selection);
                    }
                    else if (XhasNext > -1)
                    {
                        selection = XhasNext;
                        playerY.MakeMove(selection);
                        Console.WriteLine(selection);
                    }
                    else
                    {
                        int[] preferredMoves = { 4, 0, 2, 6, 8, 1, 3, 5, 7 };

                        for (int i = 0; i < preferredMoves.Length; i++)
                        {
                            if (gameArray[preferredMoves[i]] == " ")
                            {
                                selection = preferredMoves[i];
                                playerY.MakeMove(selection);
                                break;
                            }
                        }
                    }

                    //Console.Clear();
                }


                DisplayBoardGrid();
                DisplayGrid(selection);

                if (gamePlayer == "X")
                    result = gameBoard.IsWinner(playerX);
                else
                    result = gameBoard.IsWinner(playerY);

                if (result)
                    AnnounceWinner();
                else
                    tieGame = gameBoard.IsFull();

                if (tieGame)
                    IsTie();

                if (gamePlayer == "X")
                    gamePlayer = "Y";
                else
                    gamePlayer = "X";
            }
            while (!(tieGame || result));

        }

        public void DisplayBoardGrid()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t 0 | 1 | 2 ");
            Console.WriteLine("\t------------");
            Console.WriteLine("\t 3 | 4 | 5 ");
            Console.WriteLine("\t------------");
            Console.WriteLine("\t 6 | 7 | 8 ");
            Console.WriteLine("\n\n");
        }

        public int IsPlaying(string thePlayer)
        {
            int userselection;

            Console.Write("Player {0}, choose your location: ", thePlayer);
            while ((int.TryParse(Console.ReadLine(), out userselection) == false) || (userselection > 8) || (gameArray[userselection] != " "))
            {
                Console.WriteLine("\nPlease enter a free number between 1 and 8 that appears on the grid");
                Console.Write("\nPlayer {0}, choose your location: ", thePlayer);
            }

            if (thePlayer == "X")
            {
                playerX.MakeMove(userselection);

            }
            else
            {
                playerY.MakeMove(userselection);

            }

            Console.Clear();

            return userselection;

        }

        public void DisplayGrid(int theSelection)
        {

            gameArray[theSelection] = gamePlayer;

            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[0], gameArray[1], gameArray[2]);
            Console.WriteLine("\t------------");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[3], gameArray[4], gameArray[5]);
            Console.WriteLine("\t------------");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[6], gameArray[7], gameArray[8]);
            Console.WriteLine("\n\n\n");

        }

        public void AnnounceWinner()
        {

            Console.WriteLine("\n\n\n");
            Console.WriteLine("Player {0} has won the game!\n\n\n", gamePlayer);
        }

        public void IsTie()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("The game is a draw. No one won!\n\n\n");
        }
    }
}
