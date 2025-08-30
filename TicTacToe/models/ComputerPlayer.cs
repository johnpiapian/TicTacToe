using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ComputerPlayer : Player
    {
        public static string name = "Computer";

        public ComputerPlayer() : base(9, name) {}

        public override void MakeMove(int position)
        {
            pieces[position] = true;
        }
    }
}
