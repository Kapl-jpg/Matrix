using Enums;
using Interfaces;
using Names;
using UnityEngine;

namespace Home.Items
{
    public class SelectedItem: MonoBehaviour, IInteractable
    {
        [field:SerializeField] public ItemType Type { get; set; }

        public void Interact()
        {
            gameObject.SetActive(false);
            EventManager.Publish(EventNames.AddItem);
        }
    }
}