using System.Collections.Generic;
using General;
using General.Save;
using Names;

namespace Notebook
{
    public class NotebookEntrySelector : Subscriber
    {
        private readonly Dictionary<EntryData, NotebookEntry> _entries = new();

        public void AddEntry(EntryData data,NotebookEntry entry)
        {
            _entries.Add(data, entry);
        }
        
        [Event(EventNames.LockEntry)]
        private void LockNotebookEntry((EntryData first,EntryData second) data)
        {
            foreach (var notebookEntry in SaveNotebookData.NotebookEntries)
            {
                if (notebookEntry.ID == data.first.ID || notebookEntry.ID == data.second.ID)
                {
                    _entries[notebookEntry].LockButton();
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
                    _entries[notebookEntry]?.ActivateButton();
                    continue;
                }
                _entries[notebookEntry]?.DeactivateButton();
            }
        }
    }
}
