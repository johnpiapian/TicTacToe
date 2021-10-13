using System.Collections;

namespace TicTacToe
{
    abstract class Player
    {
        protected BitArray pieces;

        public Player(int arraySize)
        {
            pieces = new BitArray(arraySize, false);
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
