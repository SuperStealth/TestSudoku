using Sudoku.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sudoku
{
    public class Starter : MonoBehaviour
    {
        private void Awake()
        {
            var sceneService = GameServices.Add<SceneService>(new SceneService());
            sceneService.GoToScene("MainScene");
        }
    }
}

