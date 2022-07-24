using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Sudoku.Services
{
    public class SceneService : IGameService
    {
        public bool Started { get; private set; }

        public Task<bool> Init()
        {
            Started = true;
            return Task.FromResult(true);
        }

        public void GoToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

