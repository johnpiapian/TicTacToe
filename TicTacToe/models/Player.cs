using System.Collections;

namespace TicTacToe
{
    abstract class Player
    {
        protected BitArray pieces;
        protected string _playerName;

        public Player(int arraySize, string name)
        {
            PlayerName = name;
            pieces = new BitArray(arraySize, false);
        }

        public BitArray Pieces
        {
            get
            {
                return pieces;
            }
        }

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
            }
        }

        public abstract void MakeMove(int position);
    }
}
