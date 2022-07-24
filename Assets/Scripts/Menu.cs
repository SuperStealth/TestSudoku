using Sudoku.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button easyButton;
        [SerializeField] private Button mediumButton;
        [SerializeField] private Button hardButton;

        private SceneService sceneService;

        private void Awake()
        {
            sceneService = GameServices.Get<SceneService>();

            easyButton.onClick.AddListener(StartEasyGame);
            mediumButton.onClick.AddListener(StartMediumGame);
            hardButton.onClick.AddListener(StartHardGame);
        }

        private void StartEasyGame()
        {
            GameSettings.CurrentLevelFilledCells = GameSettings.LowDifficultyLeftCells;
            sceneService.GoToScene("MainScene");
        }

        private void StartMediumGame()
        {
            GameSettings.CurrentLevelFilledCells = GameSettings.MediumDifficultyLeftCells;
            sceneService.GoToScene("MainScene");
        }

        private void StartHardGame()
        {
            GameSettings.CurrentLevelFilledCells = GameSettings.HardDifficultyLeftCells;
            sceneService.GoToScene("MainScene");
        }

        private void OnDestroy()
        {
            easyButton.onClick.RemoveListener(StartEasyGame);
            mediumButton.onClick.RemoveListener(StartMediumGame);
            hardButton.onClick.RemoveListener(StartHardGame);
        }
    }
}

