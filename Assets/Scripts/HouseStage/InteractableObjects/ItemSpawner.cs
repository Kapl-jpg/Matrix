using System.Collections.Generic;
using General.Save;
using Interfaces;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<ItemSpawnData> spawns;
        [SerializeField] private Transform objectsParent;
        
        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            foreach (var spawnData in spawns)
            {
                var spawnPoint = spawnData.points[Random.Range(0, spawnData.points.Count)];

                var item = Instantiate(spawnData.prefab, spawnPoint.point.position, Quaternion.Euler(spawnPoint.point.eulerAngles));
                item.transform.localScale = spawnPoint.point.localScale;
                item.transform.SetParent(objectsParent);
                
                item.TryGetComponent(out ICollectable collectableItem);
                var tempData = collectableItem.EntryData;
                tempData.Place = spawnPoint.place;
                tempData.EventName = spawnData.eventName;
                collectableItem.EntryData = tempData;
                
                item.TryGetComponent(out ICollectable collectable);
                collectable?.SetName(SavePointName.GetName);
            }
        }
    }
}