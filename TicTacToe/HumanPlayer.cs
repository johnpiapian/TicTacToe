using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TicTacToe
{
    class HumanPlayer : Player
    {

        public HumanPlayer()
        {
            pieces = new BitArray(9, false);
        }

        public override void MakeMove(int position)
        {
            pieces[position] = true;
        }
    }
}
