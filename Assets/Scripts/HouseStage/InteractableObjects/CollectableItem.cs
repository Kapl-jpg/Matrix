using Enums;
using General.Save;
using Interfaces;
using Notebook;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    public class CollectableItem: MonoBehaviour, IInteractable, ICollectable
    {
        [field:SerializeField] public EntryData EntryData { get; set; }
        [field:SerializeField] public ItemType Type { get; set; }
        [field:SerializeField, Range(0f, 1f)] public float UnknownInformationChance { get; set; }

        public void Interact()
        {
            SaveNotebookData.AddData(EntryData, UnknownInformationChance);
            gameObject.SetActive(false);
        }
    }
}