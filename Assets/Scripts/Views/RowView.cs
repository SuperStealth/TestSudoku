using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class RowView : MonoBehaviour
    {
        [SerializeField] private CellView[] cells;
        [SerializeField] private int rowNumber;

        public Action<int, int> ButtonClick;

        private void Awake()
        {
            foreach (var cell in cells)
            {
                cell.OnButtonPressed += ButtonClicked;
            }
        }

        public CellView GetCell(int cell)
        {
            return cells[cell];
        }

        private void ButtonClicked(int cellNumber)
        {
            ButtonClick?.Invoke(rowNumber, cellNumber);
        }

        private void OnDestroy()
        {
            foreach (var cell in cells)
            {
                cell.OnButtonPressed -= ButtonClicked;
            }
        }
    }
}