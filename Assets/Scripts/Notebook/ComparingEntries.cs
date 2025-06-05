using General.Save;
using Names;

namespace Notebook
{
    public class ComparingEntries: Subscriber
    {
        private EntryData _originalData;
        
        [Event(EventNames.Notebook.SelectNotebookEntry)]
        private void SelectOriginalEntry(EntryData entryData)
        {
            _originalData = entryData;
        }

        [Event(EventNames.Notebook.SelectMergeEntry)]
        private void SelectMergeEntry(EntryData entryData)
        {
            if (_originalData.Name == entryData.Name)
            {
                _originalData.Merged = true;
                entryData.Merged = true;
                
                EventManager.Publish(EventNames.Notebook.LockEntry,(_originalData.ID, entryData.ID));
                SaveNumberMatches.AddMatch(_originalData.Name);
            }
        }
    }
}