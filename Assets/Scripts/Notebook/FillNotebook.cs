using System.Collections.Generic;
using General.Save;
using UnityEngine;

namespace Notebook
{
    public class FillNotebook : MonoBehaviour
    {
        [SerializeField] private GameObject content;
        [SerializeField] private NotebookEntry notebookEntryPrefab;
    
        [SerializeField] private NotebookEntrySelector notebookEntrySelector;
        
        private void Start()
        {
            SetData();
        }

        private void SetData()
        {
            var entries = new Dictionary<int, NotebookEntry>();
            foreach (var notebookEntry in SaveNotebookData.NotebookEntries)
            {
                var entry = Instantiate(notebookEntryPrefab, content.transform, false);
                entry.TryGetComponent(out RectTransform rectTransform);
                rectTransform.anchoredPosition = Vector2.zero;
                entry.SetData(notebookEntry);
                entries.Add(notebookEntry.ID, entry);
            }
            
            notebookEntrySelector.CheckEntries(entries);
        }
    }
}
