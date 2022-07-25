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
        private LevelService levelService;

        private void Awake()
        {
            sceneService = GameServices.Get<SceneService>();
            levelService = GameServices.Get<LevelService>();

            easyButton.onClick.AddListener(() => StartGame(Difficulty.Easy));
            mediumButton.onClick.AddListener(() => StartGame(Difficulty.Medium));
            hardButton.onClick.AddListener(() => StartGame(Difficulty.Hard));
        }

        private void StartGame(Difficulty level)
        {
            levelService.SetDifficulty(level);
            sceneService.GoToScene("MainScene");
        }

        private void OnDestroy()
        {
            easyButton.onClick.RemoveAllListeners();
            mediumButton.onClick.RemoveAllListeners();
            hardButton.onClick.RemoveAllListeners();
        }
    }
}