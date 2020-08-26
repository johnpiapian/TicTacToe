﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class ComputerPlayer : Player
    {

        public ComputerPlayer()
        {
            pieces = new BitArray(9, false);
        }

        public override void MakeMove(int position)
        {
            pieces[position] = true;
        }
    }
}
