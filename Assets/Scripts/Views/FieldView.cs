using System;
using UnityEngine;

namespace Sudoku
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private RowView[] rows;

        private int selectedRow;
        private int selectedColumn;

        private void Awake()
        {
            foreach (var row in rows)
            {
                row.ButtonClick += CellClicked;
            }    
        }

        public void UpdateView(Field field)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    int cellValue = field.GetCell(i, j);
                    if (cellValue != 0)
                    {
                        rows[i].GetCell(j).SetCellValue(cellValue);
                    }                  
                }
            }
        }

        private void CellClicked(int rowNumber, int cellNumber)
        {
            rows[selectedRow].GetCell(selectedColumn).SetCellBackgroundColor(false);
            rows[rowNumber].GetCell(cellNumber).SetCellBackgroundColor(true);
            selectedRow = rowNumber;
            selectedColumn = cellNumber;
        }

        private void OnDestroy()
        {
            foreach (var row in rows)
            {
                row.ButtonClick -= CellClicked;
            }
        }
    }
}

