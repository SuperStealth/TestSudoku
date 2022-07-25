using Sudoku.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private FieldView fieldView;
        [SerializeField] private Numbers numbers;
        [SerializeField] private TextMeshProUGUI livesText;
        [SerializeField] private TextMeshProUGUI hintCountText;
        [SerializeField] private TextMeshProUGUI endGameText;
        [SerializeField] private GameObject endGameScreen;
        [SerializeField] private Button nextGameButton;
        [SerializeField] private Button hintButton;
        [SerializeField] private Button undoButton;

        private SceneService sceneService;
        private LevelService levelService;

        private Field field;

        private int livesCount;
        private int hintCount;

        private void Awake()
        {
            sceneService = GameServices.Get<SceneService>();
            levelService = GameServices.Get<LevelService>();

            numbers.NumberClick += OnNumberClicked;
            undoButton.onClick.AddListener(UndoButtonClicked);
            hintButton.onClick.AddListener(HintButtonClicked);
            nextGameButton.onClick.AddListener(NextGameButtonClicked);
            StartGame();           
        }

        private void StartGame()
        {
            var fieldGenerator = new FieldGenerator();
            field = fieldGenerator.GenerateField(levelService.GetFilledCells(), Constants.FlushCounts);
            fieldView.UpdateView(field);
            livesCount = Constants.LivesCount;
            hintCount = Constants.HintCount;
        }

        private void OnNumberClicked(int number)
        {
            var coords = fieldView.GetSelectedCellCoords();
            if (field.TrySetCell(coords.X,coords.Y,number))
            {
                fieldView.UpdateView(field);
                var cellView = fieldView.GetSelectedCellView();
                if (field.CheckNumberIsCorrect(coords.X, coords.Y, number))
                {
                    cellView.SetCellColor(true);
                    if (field.CheckWinCondition())
                    {
                        EndGame(true);
                    }
                }
                else
                {
                    cellView.SetCellColor(false);
                    livesCount--;
                    livesText.text = livesCount.ToString();

                    if (livesCount <= 0)
                    {
                        EndGame(false);
                    }
                }
            }
        }

        private void EndGame(bool isWin)
        {
            endGameScreen.SetActive(true);
            endGameText.text = isWin ? "You WIN!!!" : "You lost...";
        }

        private void UndoButtonClicked()
        {
            field.EraseLastSettedCell();
            fieldView.UpdateView(field);
        }

        private void HintButtonClicked()
        {
            if (hintCount > 0)
            {
                hintCount--;
                var cellCoords = field.GetHint();
                fieldView.UpdateView(field);
                var cell = fieldView.GetCell(cellCoords);
                cell.TweenCellHinted();
                hintCountText.text = hintCount.ToString();
            }           
        }

        private void NextGameButtonClicked()
        {
            sceneService.GoToScene("MenuScene");
        }

        private void OnDestroy()
        {
            numbers.NumberClick -= OnNumberClicked;
            undoButton.onClick.RemoveListener(UndoButtonClicked);
            hintButton.onClick.RemoveListener(HintButtonClicked);
            nextGameButton.onClick.RemoveListener(NextGameButtonClicked);
        }
    }
}