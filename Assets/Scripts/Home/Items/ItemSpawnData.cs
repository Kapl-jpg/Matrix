using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Home.Items
{
    [Serializable] 
    public class ItemSpawnData
    {
        public ItemType type;
        public GameObject prefab;
        public List<Transform> spawnPoints;
    }
}