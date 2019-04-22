using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<byte>> grid = new List<List<byte>>() {
                new List<byte>() { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                new List<byte>() { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                new List<byte>() { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                new List<byte>() { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                new List<byte>() { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                new List<byte>() { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                new List<byte>() { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                new List<byte>() { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                new List<byte>() { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
            };

            Console.WriteLine(Checker.IsValidGrid(grid));
            Console.ReadLine();
        }
    }
}
