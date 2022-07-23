using Sudoku.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : IGameService
{
    public bool Started { get; private set; }

    public async Task<bool> Init()
    {
        Started = true;
        return Task.CompletedTask.IsCompleted;
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
