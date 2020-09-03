using System;

namespace TicTacToe
{
    class Program
    {
        static int Player = 1;
        static int PlayerWhoWon = 0;
        static int Turn = 0;
        static bool Running = true;
        static char[] BoardArray = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static void Main(string[] args)
        {
            //introduction menu
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  _______ _        _______           _______         _ ");
            Console.WriteLine(@" |__   __(_)      |__   __|         |__   __|       | |");
            Console.WriteLine(@"    | |   _  ___     | | __ _  ___     | | ___   ___| |");
            Console.WriteLine(@"    | |  | |/ __|    | |/ _` |/ __|    | |/ _ \ / _ \ |");
            Console.WriteLine(@"    | |  | | (__     | | (_| | (__     | | (_) |  __/_|");
            Console.WriteLine(@"    |_|  |_|\___|    |_|\__,_|\___|    |_|\___/ \___(_)");
            Console.ResetColor();
            Console.WriteLine("Welcome to Tic Tac Toe, press any key to begin");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RULES");
            Console.ResetColor();
            Console.WriteLine("Tic Tac Toe is a two player turn based game." +
                              "\nIt's you vs your opponent..." +
                              "\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RULES");
            Console.ResetColor();
            Console.WriteLine("Players are represented with a unique signature." +
                              "\nPlayer 1 = O. Player 2 = X" +
                              "\n\nThe first player to score three signatures in a row is the winner" +
                              "\nGood luck players!" +
                              "\nNow press any key to begin...");
            Console.ReadKey();
            Console.Clear();

            //main game loop
            while (Running)
            {
                GameBoard.Render(BoardArray);
                TakeATurn();
                CheckForWin();
            }
            Environment.Exit(0);

        }
        public static void TakeATurn()
        {
            Turn++;
            if (Turn == 10)
            {
                Draw();
            }
            else
            {
                Console.WriteLine("\nReady Player {0}: It's your turn!", Player);
                Console.Write("> ");
                int Input = Int32.Parse(Console.ReadLine());
                if (Player == 1)
                {
                    if (BoardArray[Input - 1] == 'X' || BoardArray[Input - 1] == 'O')
                    {
                        DisplayErrorMessage(Player);
                        Player = 1;
                        Turn--;
                    }
                    else 
                    {
                        BoardArray[Input - 1] = 'O';
                        Player = 2;
                    }
                }
                else
                {
                    if (BoardArray[Input - 1] == 'X' || BoardArray[Input - 1] == 'O')
                    {
                        DisplayErrorMessage(Player);
                        Player = 2;
                        Turn--;
                    }
                    else
                    {
                        BoardArray[Input - 1] = 'X';
                        Player = 1;
                    }
                    Player = 1;
                }
                Console.Clear();
            }
        }
        public static void Draw()
        {
            Console.WriteLine("Aw gosh... it's a draw.");
            BoardReset();
        }

        public static void BoardReset()
        {
            Console.WriteLine("To reset the game and try again, press any key!" +
                              "\nAlternatively, press Escape to quit.");
            if (Console.ReadKey().Key.Equals(ConsoleKey.Escape)) Running = false;
            char[] BoardArrayReset = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            BoardArray = BoardArrayReset;
            Turn = 0;
            Player = 1;
            Console.Clear();
        }

        public static void CheckForWin()
        {
            //check for horizontal win
            if ((BoardArray[0].Equals('O') && BoardArray[1].Equals('O') && BoardArray[2].Equals('O'))
            || (BoardArray[3].Equals('O') && BoardArray[4].Equals('O') && BoardArray[5].Equals('O'))
            || (BoardArray[6].Equals('O') && BoardArray[7].Equals('O') && BoardArray[8].Equals('O')))
            {
                PlayerWhoWon = 1;
            }
            if ((BoardArray[0].Equals('X') && BoardArray[1].Equals('X') && BoardArray[2].Equals('X'))
            || (BoardArray[3].Equals('X') && BoardArray[4].Equals('X') && BoardArray[5].Equals('X'))
            || (BoardArray[6].Equals('X') && BoardArray[7].Equals('X') && BoardArray[8].Equals('X')))
            {
                PlayerWhoWon = 2;
            }

            //check for vertical win
            if ((BoardArray[0].Equals('O') && BoardArray[3].Equals('O') && BoardArray[6].Equals('O'))
            || (BoardArray[1].Equals('O') && BoardArray[4].Equals('O') && BoardArray[7].Equals('O'))
            || (BoardArray[2].Equals('O') && BoardArray[5].Equals('O') && BoardArray[8].Equals('O')))
            {
                PlayerWhoWon = 1;
            }
            if ((BoardArray[0].Equals('X') && BoardArray[3].Equals('X') && BoardArray[6].Equals('X'))
            || (BoardArray[1].Equals('X') && BoardArray[4].Equals('X') && BoardArray[7].Equals('X'))
            || (BoardArray[2].Equals('X') && BoardArray[5].Equals('X') && BoardArray[8].Equals('X')))
            {
                PlayerWhoWon = 2;
            }

            //check for diagonal win
            if ((BoardArray[0].Equals('O') && BoardArray[4].Equals('O') && BoardArray[8].Equals('O'))
            || (BoardArray[2].Equals('O') && BoardArray[4].Equals('O') && BoardArray[6].Equals('O')))
            {
                PlayerWhoWon = 1;
            }
            if ((BoardArray[0].Equals('X') && BoardArray[4].Equals('X') && BoardArray[8].Equals('X'))
            || (BoardArray[2].Equals('X') && BoardArray[4].Equals('X') && BoardArray[6].Equals('X')))
            {
                PlayerWhoWon = 2;
            }

            if (PlayerWhoWon != 0)
            {
                Console.WriteLine("Player {0} won, congratulations!" +
                                  "\nTurns Taken: {1}", PlayerWhoWon, Turn);
                WinArt();
                BoardReset();
                PlayerWhoWon = 0;
            }
        }

        public static void DisplayErrorMessage(int Player)
        {
            Console.Clear();
            GameBoard.Render(BoardArray);
            Console.WriteLine("Try again, Player {0}! That space has already been taken!" + 
                              "\nPress any key to continue.", Player);
            Console.ReadKey();
        }

        public static void WinArt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@" __     __          __          ___       _ ");
            Console.WriteLine(@" \ \   / /          \ \        / (_)     | |");
            Console.WriteLine(@"  \ \_/ /__  _   _   \ \  /\  / / _ _ __ | |");
            Console.WriteLine(@"   \   / _ \| | | |   \ \/  \/ / | | '_ \| |");
            Console.WriteLine(@"    | | (_) | |_| |    \  /\  /  | | | | |_|");
            Console.WriteLine(@"    |_|\___/ \__,_|     \/  \/   |_|_| |_(_)");
            Console.ResetColor();
        }
    }
}
