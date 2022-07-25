using System.Threading.Tasks;

namespace Sudoku.Services
{
    public class LevelService : IGameService
    {
        public bool Started { get; private set; }

        private Difficulty level;

        public Task<bool> Init()
        {
            Started = true;
            return Task.FromResult(true);
        }

        public void SetDifficulty(Difficulty level)
        {
            this.level = level;
        }

        public int GetFilledCells()
        {
            switch (level)
            {
                case Difficulty.Easy:
                    return GameSettings.LowDifficultyLeftCells;                    

                case Difficulty.Medium:
                    return GameSettings.MediumDifficultyLeftCells;

                case Difficulty.Hard:
                    return GameSettings.HardDifficultyLeftCells;
            }
            return GameSettings.LowDifficultyLeftCells;
        }
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}