using Enums;
using General.Save;
using Interfaces;
using Names;
using Notebook;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    public class CollectableItem: MonoBehaviour, IInteractable, ICollectable
    {
        [field:SerializeField] public EntryData EntryData { get; set; }

        [field:SerializeField] public ItemType Type { get; set; }

        public void Interact()
        {
            SaveNotebookData.AddData(EntryData);
            gameObject.SetActive(false);
        }
    }
}