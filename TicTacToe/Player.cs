using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    abstract class Player
    {
        protected BitArray pieces;

        public Player()
        {
            pieces = new BitArray(9, false);
        }

        public BitArray Pieces
        {
            get
            {
                return pieces;
            }
        }

        public abstract void MakeMove(int position);
    }
}
