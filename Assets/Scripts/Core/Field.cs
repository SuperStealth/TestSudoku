using System;

namespace Sudoku
{
    public class Field
    {

        private int[][] cells;

        private CellCoords lastSettedCell;

        public Field(int[][] cells)
        {
            this.cells = cells;
        }

        public int GetCellValue(int x, int y)
        {
            return cells[x][y];
        }

        public bool TrySetCell(int x, int y, int value)
        {
            if (cells[x][y] == 0)
            {
                cells[x][y] = value;
                lastSettedCell = new CellCoords(x, y);
                return true;
            }         
            return false;                       
        }

        public bool CheckWinCondition()
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (cells[i][j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool EraseLastSettedCell()
        {
            if (cells[lastSettedCell.X][lastSettedCell.Y] == 0)
                return false;
            cells[lastSettedCell.X][lastSettedCell.Y] = 0;
            return true;
        }

        public bool CheckNumberIsCorrect(int x, int y, int value)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                if (cells[i][y] == value && x != i)
                    return false;
                if (cells[x][i] == value && y != i)
                    return false;
            }
            for (int i = 0; i < Constants.RegionSize; i++)
            {
                for (int j = 0; j < Constants.RegionSize; j++)
                {
                    if (cells[x / Constants.RegionSize * Constants.RegionSize + i][y / Constants.RegionSize * Constants.RegionSize + j] == value && x % Constants.RegionSize != i && y % Constants.RegionSize != j)
                        return false;
                }
            }
            return true;
        }
    }
}