using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Grid
    {
        public List<List<Cell>> Cells { get; } = new List<List<Cell>>();
        public Cell ActiveCell { get; set; }

        public Grid(byte size = 9, List<List<byte>> data = null)
        {
            for (byte x = 0; x < size; x++)
            {
                Cells.Add(new List<Cell>());
                for (byte y = 0; y < size; y++)
                {
                    Cells[x].Add(new Cell(x, y, data[x][y]));
                }
            }
        }

        public void LoadGrid(string filePath)
        {
            // TODO: load grid data from path
        }

        public void SaveGrid(string filePath)
        {
            // TODO: save grid data to path
        }
    }
}
