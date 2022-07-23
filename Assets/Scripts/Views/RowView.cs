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

        public Action<int> ButtonClick;
        public CellView[] CellViews { get => cells; }

        private void Awake()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].OnButtonPressed += ButtonClicked;
            }
        }

        private void ButtonClicked()
        {
            
        }

        private void OnDestroy()
        {
            
        }
    }
}