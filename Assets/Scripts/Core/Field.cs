using System;

namespace Sudoku
{
    public class Field
    {
        const int GridSize = 9;
        const int RegionSize = 3;

        private int[][] cells;

        public Field(int[][] cells)
        {
            this.cells = cells;
        }

        public int GetCell(int x, int y)
        {
            return cells[x][y];
        }

        public bool TrySetCell(int x, int y, int value)
        {
            if (cells[x][y] == 0)
            {
                cells[x][y] = value;
            }
            else
            {
                return false;
            }
            
            return true;
        }

        public bool CheckNumberIsCorrect(int x, int y, int value)
        {
            for (int i = 0; i < GridSize; i++)
            {
                if (cells[i][y] == value)
                    return false;
                if (cells[x][i] == value)
                    return false;
            }
            for (int i = 0; i < RegionSize; i++)
            {
                for (int j = 0; j < RegionSize; j++)
                {
                    if (cells[x / RegionSize * RegionSize + i][y / RegionSize * RegionSize + j] == value)
                        return false;
                }
            }
            return true;
        }
    }
}