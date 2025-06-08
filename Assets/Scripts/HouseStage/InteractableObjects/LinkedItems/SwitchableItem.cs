using Enums;
using Interfaces;
using UnityEngine;

namespace HouseStage.InteractableObjects.LinkedItems
{
    public class SwitchableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject linkedItem;
        private static readonly int OpenAnim = Animator.StringToHash("Open");

        [field:SerializeField] public ItemType Type { get; set; }

        public void Interact()
        {
            Switch();
        }

        private void Switch()
        {
            gameObject.layer = 0;
            animator.SetTrigger(OpenAnim);
        }

        public void Ready()
        {
            linkedItem.TryGetComponent(out IMoveableItem moveableItem);
            moveableItem?.Move();
        }
    }
}