using System;
using System.Collections.Generic;
using UnityEngine;

namespace HouseStage.InteractableObjects.ItemSpawn
{
    [Serializable] 
    public class ItemSpawnData
    {
        public GameObject prefab;
        public List<ItemPositionData> points;
        public string eventName;
    }
}