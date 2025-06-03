using System.Collections.Generic;
using UnityEngine;

namespace General.Save
{
    public static class SaveNumberMatches
    {
        private static readonly Dictionary<string, int> _numberMatches = new();
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Application.quitting += OnApplicationQuit;
        }

        private static void OnApplicationQuit()
        {
            _numberMatches.Clear();
        }
        
        public static void AddMath(string name)
        {
            if(!_numberMatches.TryAdd(name, 1))
                _numberMatches[name]++;
        }

        public static int GetNumber(string name)
        {
            return _numberMatches.GetValueOrDefault(name, 0);
        }
    }
}