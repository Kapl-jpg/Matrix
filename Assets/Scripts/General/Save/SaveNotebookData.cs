using System.Collections.Generic;
using Notebook;
using UnityEngine;

namespace General.Save
{
    public static class SaveNotebookData
    {
        private static readonly List<EntryData> _notebookEntries = new();
        public static List<EntryData> NotebookEntries => _notebookEntries;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Application.quitting += OnApplicationQuit;
        }

        private static void OnApplicationQuit()
        {
            _notebookEntries.Clear();
        }

        public static void AddData(EntryData entry)
        {
            entry.ID = ID();
            entry.Day = SaveDay.CurrentDay;
            _notebookEntries.Add(entry);
        }


        private static int ID()
        {
            return _notebookEntries.Count;
        }
    }
}