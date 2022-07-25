using Sudoku.Services;
using UnityEngine;

namespace Sudoku
{
    public class Starter : MonoBehaviour
    {
        private void Awake()
        {
            var sceneService = GameServices.Add<SceneService>(new SceneService());
            var remoteConfigService = GameServices.Add<RemoteConfigService>(new RemoteConfigService());
            var levelService = GameServices.Add<LevelService>(new LevelService());
            _ = remoteConfigService.GetAndSetValues();
            sceneService.GoToScene("MenuScene");
        }
    }
}

