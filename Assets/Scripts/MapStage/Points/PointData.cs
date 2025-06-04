using System;

namespace MapStage.Points
{
    [Serializable]
    public class PointData
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsLocked {get;set; }
        public string description;
    }
}