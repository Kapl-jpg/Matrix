using Enums;
using Interfaces;
using Names;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    public class Door: MonoBehaviour, IInteractable
    {
        [field:SerializeField] public ItemType Type { get; set; }
        public void Interact()
        {
            EventManager.Publish(EventNames.LoadNotebookScene);
        }
    }
}