using System.Collections.Generic;
using General.Save;
using Interfaces;
using UnityEngine;

namespace Home.Items
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<ItemSpawnData> datas;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            foreach (var data in datas)
            {
                var spawnPoint = data.spawnPoints[Random.Range(0, data.spawnPoints.Count)];
                
                var item = Instantiate(data.prefab, spawnPoint.position,Quaternion.identity);
                item.TryGetComponent(out ICollectable collectable);
                collectable.SetName(SavePointName.PointName);
            }
        }
    }
}