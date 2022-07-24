using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class FieldGenerator
    {
        private int[][] cells;
        private Random random;

        public Field GenerateField(int numbersLeftOnField, int flushIntensity)
        {
            cells = new int[Constants.GridSize][];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new int[Constants.GridSize];
            }

            FillWithBaseField();

            random = new Random();
            Flush(flushIntensity);
            RemoveCells(numbersLeftOnField);

            Field field = new Field(cells);
            return field;
        }

        private void Flush(int numberOfActions)
        {          
            for (int i = 0; i < numberOfActions; i++)
            {
                switch (GetRandomValue(4))
                {
                    case 0:
                        SwapRowsInRegion(GetRandomValue(2), GetRandomValue(2));
                        break;
                    case 1:
                        SwapColumnsInRegion(GetRandomValue(2), GetRandomValue(2));
                        break;
                    case 2:
                        TransposeGrid();
                        break;
                    case 3:
                        SwapRowsRegion(GetRandomValue(2), GetRandomValue(2));
                        break;
                    case 4:
                        SwapColumnsRegion(GetRandomValue(2), GetRandomValue(2));
                        break;
                }
            }
        }

        private void FillWithBaseField()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    cells[i][j] = (i * 3 + i / 3 + j) % Constants.GridSize + 1;
                }
            }
        }

        private void SwapRowsInRegion(int region, int startRow)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                SwapCells(ref cells[i][region * Constants.RegionSize + startRow], ref cells[i][region * Constants.RegionSize + (startRow + 1) % Constants.RegionSize]);
            }
        }

        private void SwapColumnsInRegion(int region, int startColumn)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                SwapCells(ref cells[region * Constants.RegionSize + startColumn][i], ref cells[region * Constants.RegionSize + (startColumn + 1) % Constants.RegionSize][i]);
            }
        }

        private void SwapRowsRegion(int region1, int region2)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.RegionSize; j++)
                {
                    SwapCells(ref cells[i][region1 * Constants.RegionSize + j], ref cells[i][region2 * Constants.RegionSize + j]);
                }
            }
        }

        private void SwapColumnsRegion(int region1, int region2)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.RegionSize; j++)
                {
                    SwapCells(ref cells[region1 * Constants.RegionSize + j][i], ref cells[region2 * Constants.RegionSize + j][i]);
                }
            }
        }

        private void TransposeGrid()
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    SwapCells(ref cells[i][j], ref cells[j][i]);
                }
            }
        }

        private int GetRandomValue(int maxValue)
        {
            return random.Next(maxValue);
        }

        private void RemoveCells(int resultCellsQuantity)
        {
            HashSet<int> visitedCells = new HashSet<int>();
            int leftCells = Constants.GridSize * Constants.GridSize;
            while (leftCells > resultCellsQuantity)
            {
                int x = GetRandomValue(Constants.GridSize);
                int y = GetRandomValue(Constants.GridSize);

                if (visitedCells.Contains(x * Constants.GridSize + y)) continue;
                visitedCells.Add(x * Constants.GridSize + y);

                if (TryDeleteCell(x, y))
                {
                    leftCells--;
                }
            }          
        }

        private bool TryDeleteCell(int x, int y)
        {
            int cellValue = cells[x][y];
            cells[x][y] = 0;

            int nonZeroCellsInRow = 0;
            int nonZeroCellsInColumn = 0;
            int nonZeroCellsInRegion = 0;

            for (int i = 0; i < Constants.GridSize; i++)
            {
                if (cells[i][y] != 0)
                {
                    nonZeroCellsInRow++;
                }
                if (cells[x][i] != 0)
                {
                    nonZeroCellsInColumn++;
                }
            }
            for (int i = 0; i < Constants.RegionSize; i++)
            {
                for (int j = 0; j < Constants.RegionSize; j++)
                {
                    if (cells[x / Constants.RegionSize * Constants.RegionSize + i][y / Constants.RegionSize * Constants.RegionSize + j] != 0)
                    {
                        nonZeroCellsInRegion++;
                    }
                }
            }

            if (nonZeroCellsInColumn == 0 || nonZeroCellsInRow == 0 || nonZeroCellsInRegion == 0)
            {
                cells[x][y] = cellValue;
                return false;
            }
            return true;
        }

        private void SwapCells(ref int value1, ref int value2)
        {
            int tempValue = value1;
            value1 = value2;
            value2 = tempValue;
        }
    }
}