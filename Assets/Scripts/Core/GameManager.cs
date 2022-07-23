using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private FieldView fieldView;
        [SerializeField] private Numbers numbers;

        private Field field;

        private void Awake()
        {
            StartGame();          
        }

        private void StartGame()
        {
            var fieldGenerator = new FieldGenerator();
            field = fieldGenerator.GenerateField(22, 20);
            fieldView.UpdateView(field);
        }

        private void OnDestroy()
        {
            
        }
    }
}

