using System.Collections.Generic;
using UnityEngine;

namespace Sudoku
{
    public class HintAdvisor
    {
        private int[][] field;
        
        public void MakeHint(int[][] field, out CellCoords cellCoords, out int value)
        {
            this.field = field;

            value = FindMostFrequentNumber();
            cellCoords = FindSuitablePlace(value);
        }

        private int FindMostFrequentNumber()
        {
            Dictionary<int, int> quantities = new Dictionary<int, int>();
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    int value = field[i][j];
                    if (quantities.ContainsKey(value))
                    {
                        quantities[value]++;
                    }
                    else
                    {
                        quantities.Add(value, 1);
                    }
                }
            }

            int maxQuantity = 0;
            int maxNumber = 0;

            foreach(var quantity in quantities)
            {
                if (quantity.Value > maxQuantity && quantity.Value < 9)
                {
                    maxQuantity = quantity.Value;
                    maxNumber = quantity.Key;
                }
            }
            return maxNumber;
        }

        private CellCoords FindSuitablePlace(int value)
        {
            List<int> suitableRows = new List<int>();
            for (int i = 0; i < Constants.GridSize; i++)
            {
                bool hasValue = false;
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (field[i][j] == value)
                    {
                        hasValue = true;
                        break;
                    }
                        
                }
                if (!hasValue) suitableRows.Add(i);
            }

            List<int> suitableColumns = new List<int>();
            for (int i = 0; i < field.Length; i++)
            {
                bool hasValue = false;
                for (int j = 0; j < field.Length; j++)
                {
                    if (field[j][i] == value)
                    {
                        hasValue = true;
                        break;
                    }                       
                }
                if (!hasValue) suitableColumns.Add(i);
            }

            for (int i = 0; i < suitableRows.Count; i++)
            {
                for (int j = 0; j < suitableColumns.Count; j++)
                {
                    if (!RegionContainsValue(suitableRows[i], suitableColumns[j], value))
                    {
                        return new CellCoords(suitableRows[i], suitableColumns[j]);
                    }
                }
            }

            return new CellCoords(0, 0);
        }

        private bool RegionContainsValue(int x, int y, int value)
        {
            for (int i = 0; i < Constants.RegionSize; i++)
            {
                for (int j = 0; j < Constants.RegionSize; j++)
                {
                    if (field[x / 3 * 3 + i][y / 3 * 3 + j] == value)
                        return true;
                }
            }
            return false;
        }
    }
}