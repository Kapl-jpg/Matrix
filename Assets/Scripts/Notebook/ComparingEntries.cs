using Enums;
using General.Constants;
using General.Save;

namespace Notebook
{
    public class ComparingEntries: Subscriber
    {
        private EntryData _originalData;
        
        [Event(Names.Notebook.SELECT_NOTEBOOK_ENTRY)]
        private void SelectOriginalEntry(EntryData entryData)
        {
            _originalData = entryData;
        }

        [Event(Names.Notebook.SELECT_MERGE_ENTRY)]
        private void SelectMergeEntry(EntryData entryData)
        {
            if (_originalData.Name == entryData.Name &&
                _originalData.UnknownField == NotebookFieldType.None &&
                entryData.UnknownField == NotebookFieldType.None)
            {
                _originalData.Merged = true;
                entryData.Merged = true;

                EventManager.Publish(Names.Notebook.LOCK_ENTRY, (_originalData.ID, entryData.ID));
                SaveNumberMatches.AddMatch(_originalData.Name);
            }
        }
    }
}