using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        int[,] winningCombos = {{0,1,2},
                                {3,4,5},
                                {6,7,8},
                                {0,3,6},
                                {1,4,7},
                                {2,5,8},
                                {0,4,8},
                                {2,4,6}};
        int count;

        public Board()
        {

            count = 0;
        }

        public bool IsWinner(Player thePlayer)
        {
            bool winner = false;

            for (int rowIndex = 0; rowIndex < winningCombos.GetLength(0); rowIndex++)
            {
                if ((thePlayer.Pieces[winningCombos[rowIndex, 0]]) && (thePlayer.Pieces[winningCombos[rowIndex, 1]]) && (thePlayer.Pieces[winningCombos[rowIndex, 2]]))
                    winner = true;
            }

            return winner;

        }

        public int HasWinningMove(Player thePlayer, Player theOtherPlayer)
        {
            int nextMove = -1;

            for (int rowIndex = 0; rowIndex < winningCombos.GetLength(0); rowIndex++)
            {

                int[] column = { winningCombos[rowIndex, 0], winningCombos[rowIndex, 1], winningCombos[rowIndex, 2] };

                // check to see if there is a move that wins the game & return the move index

                if (thePlayer.Pieces[column[0]] && thePlayer.Pieces[column[1]])
                {
                    // check if the move is available
                    if (thePlayer.Pieces[column[2]] == false && theOtherPlayer.Pieces[column[2]] == false)
                    {
                        nextMove = column[2];
                        break;
                    }
                }

                if (thePlayer.Pieces[column[1]] && thePlayer.Pieces[column[2]])
                {
                    // check if the move is available
                    if (thePlayer.Pieces[column[0]] == false && theOtherPlayer.Pieces[column[0]] == false)
                    {
                        nextMove = column[0];
                        break;
                    }
                }

                if (thePlayer.Pieces[column[0]] && thePlayer.Pieces[column[2]])
                {
                    // check if the move is available
                    if (thePlayer.Pieces[column[1]] == false && theOtherPlayer.Pieces[column[1]] == false)
                    {
                        nextMove = column[1];
                        break;
                    }
                }

            }

            return nextMove;
        }

        public bool IsFull()
        {
            bool tie = false;

            if (count >= 8)
                tie = true;

            count++;

            return tie;
        }
    }
}
