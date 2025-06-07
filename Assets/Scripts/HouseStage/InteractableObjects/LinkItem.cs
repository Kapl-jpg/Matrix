using Interfaces;
using UnityEngine;

namespace HouseStage.InteractableObjects
{
    public class LinkItem : MonoBehaviour, IMoveableItem
    {
        [SerializeField] private Animator currentAnimator;
        
        private static readonly int OpenAnim = Animator.StringToHash("Open");
        
        public void Move()
        {
            currentAnimator.SetTrigger(OpenAnim);
        }
    }
}