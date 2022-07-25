using System.Collections.Generic;

namespace Sudoku
{
    public class Field
    {
        private int[][] cells;

        private Stack<CellCoords> filledCells;

        private HashSet<CellCoords> incorrectCells;

        private HintAdvisor advisor;

        public Field(int[][] cells)
        {
            this.cells = cells;
            filledCells = new Stack<CellCoords>();
            incorrectCells = new HashSet<CellCoords>();
            advisor = new HintAdvisor();
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
                filledCells.Push(new CellCoords(x, y));
                return true;
            }         
            return false;                       
        }

        public bool CheckWinCondition()
        {
            if (incorrectCells.Count > 0)
                return false;

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
            if (filledCells.Count == 0)
                return false;

            var cell = filledCells.Pop();
            cells[cell.X][cell.Y] = 0;

            var cellCoords = new CellCoords(cell.X, cell.Y);
            if (incorrectCells.Contains(cellCoords))
            {
                incorrectCells.Remove(cellCoords);
            }
            
            return true;
        }

        public bool CheckNumberIsCorrect(int x, int y, int value)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                if (cells[i][y] == value && x != i)
                {
                    incorrectCells.Add(new CellCoords(x, y));
                    return false;
                }
                    
                if (cells[x][i] == value && y != i)
                {
                    incorrectCells.Add(new CellCoords(x, y));
                    return false;
                }                   
            }
            for (int i = 0; i < Constants.RegionSize; i++)
            {
                for (int j = 0; j < Constants.RegionSize; j++)
                {
                    int xCoord = x / Constants.RegionSize * Constants.RegionSize + i;
                    int yCoord = y / Constants.RegionSize * Constants.RegionSize + j;
                    if (cells[xCoord][yCoord] == value && x % Constants.RegionSize != i && y % Constants.RegionSize != j)
                    {
                        incorrectCells.Add(new CellCoords(x, y));
                        return false;
                    }                    
                }
            }
            return true;
        }

        public CellCoords GetHint()
        {
            advisor.MakeHint(cells, out var cellCoords, out int value);
            cells[cellCoords.X][cellCoords.Y] = value;
            return cellCoords;
        }
    }
}