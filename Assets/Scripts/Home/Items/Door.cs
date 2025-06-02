using Enums;
using Interfaces;
using Names;
using UnityEngine;

namespace Home.Items
{
    public class Door: MonoBehaviour, IInteractable
    {
        [field:SerializeField] public ItemType Type { get; set; }
        public void Interact()
        {
            EventManager.Publish(EventNames.LoadNotebook);
        }
    }
}