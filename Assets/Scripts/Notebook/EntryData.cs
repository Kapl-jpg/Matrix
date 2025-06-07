using System;

namespace Notebook
{
    [Serializable]
    public struct EntryData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Day { get; set; }
        public bool Merged { get; set; }
        public string Place { get; set; }
        public string EventName { get; set; }
    }
}