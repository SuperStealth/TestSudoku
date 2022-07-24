using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class Numbers : MonoBehaviour
    {
        [SerializeField] private NumberView[] numberViews;

        public Action<int> NumberClick;

        private void Awake()
        {
            foreach (var numberView in numberViews)
            {
                numberView.ButtonPressed += OnNumberClick;
            }
        }

        private void OnNumberClick(int number)
        {
            NumberClick?.Invoke(number);
        }

        private void OnDestroy()
        {
            foreach (var numberView in numberViews)
            {
                numberView.ButtonPressed -= OnNumberClick;
            }
        }
    }
}