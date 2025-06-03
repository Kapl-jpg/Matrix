using Notebook;

namespace Interfaces
{
    public interface ICollectable
    {
        public EntryData EntryData { get; }

        public void SetName(string name)
        {
            EntryData.name = name;
        }
    }
}