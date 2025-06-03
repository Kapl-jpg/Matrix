using General;
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
            foreach (var notebookEntry in SaveData.Notebooks)
            {
                var entry = Instantiate(notebookEntryPrefab);
                entry.transform.SetParent(content.transform);
                entry.TryGetComponent(out RectTransform rectTransform);
                rectTransform.localScale = Vector3.one;
                rectTransform.SetLocalPositionAndRotation(Vector2.zero, Quaternion.identity);
                entry.SetData(notebookEntry);
                notebookEntrySelector.AddEntry(notebookEntry, entry);
            }
        }
    }
}
