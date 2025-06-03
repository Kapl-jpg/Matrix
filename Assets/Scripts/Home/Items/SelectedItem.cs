using Enums;
using General;
using General.Save;
using Interfaces;
using Names;
using Notebook;
using UnityEngine;

namespace Home.Items
{
    public class SelectedItem: MonoBehaviour, IInteractable, ICollectable
    {
        [field:SerializeField] public EntryData EntryData { get; set; }

        [field:SerializeField] public ItemType Type { get; set; }

        public void Interact()
        {
            gameObject.SetActive(false);
            EventManager.Publish(EventNames.AddItem);
            SaveNotebookData.AddData(EntryData);
        }

    }
}