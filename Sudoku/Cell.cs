using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Cell
    {
        public byte X { get; }
        public byte Y { get; }
        public byte Value { get; set; }

        public Cell(byte x, byte y, byte value = 0)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
}
