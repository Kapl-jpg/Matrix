using System.Collections.Generic;
using Enums;
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

        public static void AddData(EntryData entry, float unknownValue)
        {
            var rand = Random.value;
            entry.UnknownField = NotebookFieldType.None;
            
            if (rand < unknownValue)
            {
                var randomField = Random.Range(1, 4);
                entry.UnknownField = (NotebookFieldType)randomField;
            }
            
            entry.ID = ID();
            entry.Day = SaveDay.CurrentDay;
            _notebookEntries.Add(entry);
        }
        
        public static void ChangeMerge(int index)
        {
            var entry = _notebookEntries[index];
            entry.Merged = true;
            _notebookEntries[index] = entry;
        }
        
        private static int ID()
        {
            return _notebookEntries.Count;
        }
    }
}