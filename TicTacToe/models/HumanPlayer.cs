using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TicTacToe
{
    class HumanPlayer : Player
    {
        public static string name = "Human";

        public HumanPlayer() : base(9, name) {}

        public override void MakeMove(int position)
        {
            pieces[position] = true;
        }
    }
}
