using Enums;
using General.Constants;
using Interfaces;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    public class Door: MonoBehaviour, IInteractable
    {
        [field:SerializeField] public ItemType Type { get; set; }
        public void Interact()
        {
            EventManager.Publish(Names.LOAD_NOTEBOOK_SCENE);
        }
    }
}