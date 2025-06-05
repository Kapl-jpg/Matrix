using System.Collections.Generic;
using UnityEngine;

namespace General.Save
{
    public static class SaveNumberMatches
    {
        private static readonly Dictionary<string, int> NumberMatches = new();
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Application.quitting += OnApplicationQuit;
        }

        private static void OnApplicationQuit()
        {
            NumberMatches.Clear();
        }
        
        public static void AddMatch(string name)
        {
            if(!NumberMatches.TryAdd(name, 1))
                NumberMatches[name]++;
        }

        public static int GetNumber(string name)
        {
            return NumberMatches.GetValueOrDefault(name, 0);
        }

    }
}