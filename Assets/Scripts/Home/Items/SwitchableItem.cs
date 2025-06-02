using Enums;
using Interfaces;
using UnityEngine;

namespace Home.Items
{
    public class SwitchableItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject linkedItem;
        private static readonly int SwitchAnim = Animator.StringToHash("switch");

        [field:SerializeField] public ItemType Type { get; set; }

        public void Interact()
        {
            Switch();
        }

        private void Switch()
        {
            animator.SetTrigger(SwitchAnim);
        }

        public void Ready()
        {
            linkedItem.TryGetComponent(out IMoveableItem moveableItem);
            moveableItem?.Move();
        }
    }
}