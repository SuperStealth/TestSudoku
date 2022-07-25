using Firebase.RemoteConfig;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Sudoku.Services
{
    public class RemoteConfigService : IGameService
    {
        public bool Started {get; private set;}

        public Task<bool> Init()
        {                      
            return Task.FromResult(true);
        }

        public async Task GetAndSetValues()
        {
            Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
            await fetchTask;
            await FirebaseRemoteConfig.DefaultInstance.ActivateAsync();
            GameSettings.LowDifficultyLeftCells = (int)FirebaseRemoteConfig.DefaultInstance.GetValue("lowDifficultyLeftCells").LongValue;
            GameSettings.MediumDifficultyLeftCells = (int)FirebaseRemoteConfig.DefaultInstance.GetValue("mediumDifficultyLeftCells").LongValue;
            GameSettings.HardDifficultyLeftCells = (int)FirebaseRemoteConfig.DefaultInstance.GetValue("hardDifficultyLeftCells").LongValue;
        }
    }
}