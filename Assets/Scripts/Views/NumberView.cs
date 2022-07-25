using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class NumberView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private int number;

        public Action<int> ButtonPressed;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonPressed);
        }

        private void OnButtonPressed()
        {
            ButtonPressed?.Invoke(number);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnButtonPressed);
        }
    }
}