using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class Checker
    {
        public static bool IsValidGrid(List<List<byte>> grid)
        {
            return AreAllBlocksValid(grid) && AreAllColumnsValid(grid) && AreAllRowsValid(grid);
        }

        private static bool IsValidCell(byte cell) => cell > 0 && cell < 10;

        private static bool AreAllBlocksValid(List<List<byte>> grid)
        {
            var blockWidth = 3;
            var blockHeight = 3;
            var rowBlocks = 3;
            var columnBlocks = 3;

            for (var blockX = 0; blockX < rowBlocks; blockX++)
            {
                for (var blockY = 0; blockY < columnBlocks; blockY++)
                {
                    for (var x = 0; x < blockWidth; x++)
                    {
                        var foundValues = new List<byte>();

                        for (var y = 0; y < blockHeight; y++)
                        {
                            var cell = grid[x + blockX * blockWidth][y + blockY * blockHeight];
                            if (!IsValidCell(cell) || foundValues.Any(v => v == cell)) return false;
                            foundValues.Add(cell);
                        }
                    }
                }
            }
            return true;
        }

        private static bool AreAllColumnsValid(List<List<byte>> grid)
        {
            for (var x = 0; x < grid.Count; x++)
            {
                var foundValues = new List<byte>();

                for (var y = 0; y < grid[x].Count; y++)
                {
                    var cell = grid[y][x];
                    if (!IsValidCell(cell) || foundValues.Any(v => v == cell)) return false;
                    foundValues.Add(cell);
                }
            }
            return true;
        }

        private static bool AreAllRowsValid(List<List<byte>> grid)
        {
            for (var x = 0; x < grid.Count; x++)
            {
                var foundValues = new List<byte>();

                for (var y = 0; y < grid[x].Count; y++)
                {
                    var cell = grid[x][y];
                    if (!IsValidCell(cell) || foundValues.Any(v => v == cell)) return false;
                    foundValues.Add(cell);
                }
            }
            return true;
        }
    }
}
