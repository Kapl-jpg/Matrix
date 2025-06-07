using System;
using System.Collections.Generic;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    [Serializable] 
    public class ItemSpawnData
    {
        public GameObject prefab;
        public List<PositionData> points;
        public string eventName;
    }
}