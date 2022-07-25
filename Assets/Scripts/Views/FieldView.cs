using System;
using UnityEngine;

namespace Sudoku
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private RowView[] rows;

        private CellCoords selectedCellCoords = new CellCoords(0, 0);

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
                    rows[i].GetCell(j).SetCellValue(field.GetCellValue(i, j));               
                }
            }
        }

        public CellView GetCell(CellCoords coords)
        {
            return rows[coords.X].GetCell(coords.Y);
        }

        public CellCoords GetSelectedCellCoords()
        {
            return selectedCellCoords;
        }

        public CellView GetSelectedCellView()
        {
            return rows[selectedCellCoords.X].GetCell(selectedCellCoords.Y);
        }

        private void CellClicked(int rowNumber, int cellNumber)
        {
            rows[selectedCellCoords.X].GetCell(selectedCellCoords.Y).SetCellBackgroundColor(false);
            rows[rowNumber].GetCell(cellNumber).SetCellBackgroundColor(true);
            selectedCellCoords = new CellCoords(rowNumber, cellNumber);
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

