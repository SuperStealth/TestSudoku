using Sudoku.Services;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class Menu : MonoBehaviour
    {
        enum Difficulties
        {
            Easy,
            Medium,
            Hard
        }

        [SerializeField] private Button easyButton;
        [SerializeField] private Button mediumButton;
        [SerializeField] private Button hardButton;

        private SceneService sceneService;

        private void Awake()
        {
            sceneService = GameServices.Get<SceneService>();

            easyButton.onClick.AddListener(() => StartGame(Difficulties.Easy));
            mediumButton.onClick.AddListener(() => StartGame(Difficulties.Medium));
            hardButton.onClick.AddListener(() => StartGame(Difficulties.Hard));
        }

        private void StartGame(Difficulties level)
        {
            switch (level)
            {
                case Difficulties.Easy:
                    GameSettings.CurrentLevelFilledCells = GameSettings.LowDifficultyLeftCells;
                    sceneService.GoToScene("MainScene");
                    break;

                case Difficulties.Medium:
                    GameSettings.CurrentLevelFilledCells = GameSettings.MediumDifficultyLeftCells;
                    sceneService.GoToScene("MainScene");
                    break;

                case Difficulties.Hard:
                    GameSettings.CurrentLevelFilledCells = GameSettings.HardDifficultyLeftCells;
                    sceneService.GoToScene("MainScene");
                    break;
            }
        }

        private void OnDestroy()
        {
            easyButton.onClick.RemoveAllListeners();
            mediumButton.onClick.RemoveAllListeners();
            hardButton.onClick.RemoveAllListeners();
        }
    }
}