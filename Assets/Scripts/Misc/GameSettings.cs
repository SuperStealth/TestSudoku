using UnityEngine;

public static class GameSettings
{  
    public static int HardDifficultyLeftCells 
    { 
        get => PlayerPrefs.GetInt("hardDifficultyLeftCells", 18);
        set => PlayerPrefs.SetInt("hardDifficultyLeftCells", value);
    }

    public static int MediumDifficultyLeftCells
    {
        get => PlayerPrefs.GetInt("mediumDifficultyLeftCells", 36);
        set => PlayerPrefs.SetInt("mediumDifficultyLeftCells", value);
    }

    public static int LowDifficultyLeftCells
    {
        get => PlayerPrefs.GetInt("lowDifficultyLeftCells", 53);
        set => PlayerPrefs.SetInt("lowDifficultyLeftCells", value);
    }

    public static int CurrentLevelFilledCells { get; set; }
}