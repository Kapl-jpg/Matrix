using System;
using System.Collections.Generic;
using Notebook;
using UnityEngine;

namespace General
{
    public static class SaveData
    {
        private static readonly List<EntryData> _notebooks = new();
        public static List<EntryData> Notebooks => _notebooks;
        
        private static int daynew;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Application.quitting += OnApplicationQuit;
        }

        private static void OnApplicationQuit()
        {
            _notebooks.Clear();
        }
        
        
        public static void Add(EntryData entry)
        {
            entry.ID = ID();
            entry.Day = daynew;
            _notebooks.Add(entry);
        }

        public static void SetDay(int day)
        {
            daynew = day;
        }

        private static int ID()
        {
            return _notebooks.Count;
        }
    }
}