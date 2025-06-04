using System.Collections.Generic;
using General.Save;
using Interfaces;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<ItemSpawnData> spawns;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            foreach (var spawnData in spawns)
            {
                var spawnPoint = spawnData.points[Random.Range(0, spawnData.points.Count)];

                var item = Instantiate(spawnData.prefab, spawnPoint.position, Quaternion.identity);
                item.TryGetComponent(out ICollectable collectable);
                collectable?.SetName(SavePointName.GetName);
            }
        }
    }
}