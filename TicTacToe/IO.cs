using System;
namespace TicTacToe
{
    public class IO
    {
        public IO() {}

        public string GetString(string msg, int type=0)
        {
            switch (type)
            {
                case 1:
                    Console.Write(msg);
                    break;
                default:
                    Console.WriteLine(msg);
                    break;
            }

            return Console.ReadLine();
        }

        public int GetInt(string msg, int type=0)
        {
            int num;

            while (!int.TryParse(GetString(msg, type), out num))
            {
                Print("Invalid input! Please enter a number.");
            }

            return num;
        }

        public void Print(string msg, int type=0)
        {
            switch (type)
            {
                case 1:
                    Console.Write(msg);
                    break;
                default:
                    Console.WriteLine(msg);
                    break;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayWelcome()
        {
            Console.WriteLine("\n\nReady to have a rousing game of Tic Tac toe?  The object");
            Console.WriteLine("of the game is to get three of your pieces either across, up and down,");
            Console.WriteLine("or diagonally.  If you do, before your opponent, you win the game!");
            Console.WriteLine("\n\nHit any key when you are ready to begin");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayBoardGrid()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t 0 | 1 | 2 ");
            Console.WriteLine("\t------------");
            Console.WriteLine("\t 3 | 4 | 5 ");
            Console.WriteLine("\t------------");
            Console.WriteLine("\t 6 | 7 | 8 ");
            Console.WriteLine("\n");
        }

        public void DisplayGrid(int theSelection, string[] gameArray, string gamePlayer)
        {

            gameArray[theSelection] = gamePlayer;

            Console.WriteLine("\n");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[0], gameArray[1], gameArray[2]);
            Console.WriteLine("\t------------");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[3], gameArray[4], gameArray[5]);
            Console.WriteLine("\t------------");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[6], gameArray[7], gameArray[8]);
            Console.WriteLine("\n");
        }

        public void IsTie()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("The game is a draw. No one won!");
            Console.WriteLine("\n\n");
        }

        public void AnnounceWinner(string gamePlayer)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Player {0} has won the game!", gamePlayer);
            Console.WriteLine("\n\n");
        }
    }
}
