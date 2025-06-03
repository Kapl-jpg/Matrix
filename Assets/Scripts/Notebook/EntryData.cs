using System;

namespace Notebook
{
    [Serializable]
    public class EntryData
    {
        public int ID { get; set; }
        public string name;
        public string place;
        public string @event;
        public int Day { get; set; }
    }
}