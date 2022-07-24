using Sudoku.Services;
using UnityEngine;

namespace Sudoku
{
    public class Starter : MonoBehaviour
    {
        private void Awake()
        {
            var sceneService = GameServices.Add<SceneService>(new SceneService());
            sceneService.GoToScene("MenuScene");
        }
    }
}

