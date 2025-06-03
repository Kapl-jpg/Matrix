using System.Collections.Generic;
using General;
using General.Save;
using Names;

namespace Notebook
{
    public class NotebookEntrySelector : Subscriber
    {
        private Dictionary<EntryData, NotebookEntry> entries = new();

        public void AddEntry(EntryData data,NotebookEntry entry)
        {
            entries.Add(data, entry);
        }
        
        [Event(EventNames.LockEntry)]
        private void LockNotebookEntry((EntryData first,EntryData second) data)
        {
            foreach (var notebookEntry in SaveNotebookData.NotebookEntries)
            {
                if (notebookEntry.ID == data.first.ID || notebookEntry.ID == data.second.ID)
                {
                    entries[notebookEntry].LockButton();
                }
            }
        }

        [Event(EventNames.ChoseNotebookEntry)]
        private void ChoseNotebookEntry(EntryData entry)
        {
            foreach (var notebookEntry in SaveNotebookData.NotebookEntries)
            {
                if (notebookEntry.ID == entry.ID)
                {
                    entries[notebookEntry]?.ActivateButton();
                    continue;
                }
                entries[notebookEntry]?.DeactivateButton();
            }
        }
    }
}
