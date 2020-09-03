using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    static class GameBoard
    {
        public static void Render(char[] BoardArray)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|           |           |           |");
            Console.WriteLine("|     {0}     |     {1}     |     {2}     |", BoardArray[0], BoardArray[1], BoardArray[2]);
            Console.WriteLine("|           |           |           |");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|           |           |           |");
            Console.WriteLine("|     {0}     |     {1}     |     {2}     |", BoardArray[3], BoardArray[4], BoardArray[5]);
            Console.WriteLine("|           |           |           |");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|           |           |           |");
            Console.WriteLine("|     {0}     |     {1}     |     {2}     |", BoardArray[6], BoardArray[7], BoardArray[8]);
            Console.WriteLine("|           |           |           |");
            Console.WriteLine("-------------------------------------");
        }
    }
}
