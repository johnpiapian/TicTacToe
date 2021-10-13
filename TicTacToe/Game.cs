using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        private Player playerX;
        private Player playerY;
        private Board gameBoard;
        private IO io = new IO();
        private string[] gameArray = new string[9];
        private string gamePlayer;

        public void PlayAgain()
        {
            string response;

            io.DisplayWelcome();

            do
            {
                io.Clear();
                Play();
                response = io.GetString("Would you like to play again? (Y or N) ").ToUpper();

                // Fix substring error
                response = response.Length > 0 ? response.Substring(0, 1) : "N";
            }
            while (response == "Y");
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

            io.DisplayBoardGrid();

            do
            {
                if (gamePlayer == "X")
                {
                    selection = IsPlaying();
                }
                else
                {
                    //add AI here

                    selection = -1; //requires a default value for DisplayGrid() to function

                    int YhasNext = gameBoard.HasWinningMove(playerY, playerX);
                    int XhasNext = gameBoard.HasWinningMove(playerX, playerY);

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
                        int[] preferredMoves = { 4, 0, 2, 6, 8, 1, 3, 5, 7};

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
                }

                io.DisplayBoardGrid();
                io.DisplayGrid(selection, gameArray, gamePlayer);

                if (gamePlayer == "X")
                    result = gameBoard.IsWinner(playerX);
                else
                    result = gameBoard.IsWinner(playerY);

                if (result)
                    io.AnnounceWinner(gamePlayer);
                else
                    tieGame = gameBoard.IsFull();

                if (tieGame)
                    io.IsTie();

                if (gamePlayer == "X")
                    gamePlayer = "Y";
                else
                    gamePlayer = "X";
            }
            while (!(tieGame || result));

        }

        public int IsPlaying()
        {
            int userselection = io.GetInt($"Player {gamePlayer}, choose your location: ", 1);

            while(userselection > 8 || gameArray[userselection] != " ")
            {
                io.Print("Please enter a free number between 1 and 8 that appears on the grid");
                userselection = io.GetInt($"Player {gamePlayer}, choose your location: ", 1);
            }

            if (gamePlayer == "X")
                playerX.MakeMove(userselection);
            else
                playerY.MakeMove(userselection);

            io.Clear();

            return userselection;
        }
    }
}
