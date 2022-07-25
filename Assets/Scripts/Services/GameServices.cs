using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku.Services
{
    public static class GameServices
    {
        public static Dictionary<Type, IGameService> services = new Dictionary<Type, IGameService>();

        public static T Add<T>(IGameService service) where T : IGameService
        {
            if (services.ContainsKey(typeof(T)))
            {
                Debug.Log($"Already added service of type {typeof(T).Name}");
                return (T)services[typeof(T)];
            }
            else
            {
                services.Add(typeof(T), service);

                return (T)service;
            }
        }

        public static T Get<T>() where T : class
        {
            if (services.ContainsKey(typeof(T)))
            {
                return (T)services[typeof(T)];
            }
            return null;
        }
    }
}