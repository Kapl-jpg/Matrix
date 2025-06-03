using System;

namespace Map
{
    [Serializable]
    public class PointData
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string description;
        public bool IsLocked {get;set; }
    }
}