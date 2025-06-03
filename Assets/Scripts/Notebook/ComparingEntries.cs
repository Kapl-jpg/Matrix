using Names;

namespace Notebook
{
    public class ComparingEntries: Subscriber
    {
        private EntryData _originalData;
        
        [Event(EventNames.ChoseNotebookEntry)]
        private void SetOriginal(EntryData entryData)
        {
            _originalData.name = entryData.name;
        }

        [Event(EventNames.ChoseMergeEntry)]
        private void SetMerge(EntryData entryData)
        {
            if (_originalData.name == entryData.name)
            {
                EventManager.Publish(EventNames.LockEntry,(_originalData, entryData));
            }
        }
    }
}