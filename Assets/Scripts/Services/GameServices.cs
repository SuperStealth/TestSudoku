using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Sudoku.Services
{
    public static class GameServices
    {
        public static Dictionary<Type, IGameService> services = new Dictionary<Type, IGameService>();

        public static T Add<T>(IGameService service)
        {
            if (services.ContainsKey(typeof(T)))
            {
                Debug.Log($"Aleready added service of type {typeof(T).Name}");
                return (T)services[typeof(T)];
            }
            else
            {
                services.Add(typeof(T), service);

                return (T)service;
            }
        }
    }
}
