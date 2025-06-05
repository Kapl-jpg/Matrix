using Notebook;

namespace Interfaces
{
    public interface ICollectable
    {
        public EntryData EntryData { get; set; }

        public void SetName(string name)
        {
            var temp = EntryData;
            temp.Name = name;
            EntryData = temp;
        }
    }
}