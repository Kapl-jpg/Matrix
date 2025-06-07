using System.Collections.Generic;
using General.Save;
using Names;

namespace Notebook
{
    public class NotebookEntrySelector : Subscriber
    {
        private Dictionary<int, NotebookEntry> _dict = new();

        [Event(EventNames.Notebook.LockEntry)]
        private void LockNotebookEntry((int originalID, int mergeID) data)
        {
            for (int i = 0; i < SaveNotebookData.NotebookEntries.Count; i++)
            {
                if (SaveNotebookData.NotebookEntries[i].ID != data.originalID &&
                    SaveNotebookData.NotebookEntries[i].ID != data.mergeID) continue;
                
                SaveNotebookData.ChangeMerge(i);
                CheckEntries(_dict);
            }
        }

        public void CheckEntries(Dictionary<int, NotebookEntry> notebookEntries)
        {
            foreach (var notebookEntry in SaveNotebookData.NotebookEntries)
            {
                if (notebookEntry.Merged)
                {
                    notebookEntries[notebookEntry.ID].LockEntry();
                    continue;
                }
                
                notebookEntries[notebookEntry.ID]?.DeactivateFullEntry();
            }
            
            _dict = notebookEntries;
        }

        [Event(EventNames.Notebook.SelectNotebookEntry)]
        private void SelectNotebookEntry(EntryData entryData)
        {
            foreach (var notebookEntry in SaveNotebookData.NotebookEntries)
            {
                if (notebookEntry.ID == entryData.ID)
                {
                    _dict[entryData.ID]?.ActivateEntry();
                    continue;
                }
                
                if (notebookEntry.Merged)
                {
                    _dict[notebookEntry.ID].LockEntry();
                    continue;
                }
                
                _dict[notebookEntry.ID]?.DeactivateEntry();
            }
        }
    }
}
