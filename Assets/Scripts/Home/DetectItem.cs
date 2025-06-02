using System;
using Home.Input;
using Interfaces;
using Names;
using UnityEngine;
using UnityEngine.Serialization;

namespace Home
{
    public class DetectItem : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private float interactRange;
        [SerializeField] private float interactDistance;

        [SerializeField] private LayerMask interactMask;

        private IInteractable _interactable;
        
        public bool IsInteractableObject { get; private set; }
        private Ray _ray;

        private void Update()
        {
            _ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height) / 2);

            IsInteractableObject =
                Physics.SphereCast(_ray, interactRange, out RaycastHit hit, interactDistance, interactMask);

            if (IsInteractableObject)
            {
                if (_interactable == null)
                {
                    hit.collider.TryGetComponent(out IInteractable interactable);
                    EventManager.Publish(EventNames.ShowItemDescription, interactable.Type);
                    _interactable = interactable;
                }
            }
            else
            {
                if (_interactable != null)
                {
                    _interactable = null;
                    EventManager.Publish(EventNames.HideItemDescription);
                }

                return;
            }
            
            if (!playerInput.Interact()) return;

            _interactable?.Interact();
        }

        private void OnDrawGizmosSelected()
        {
            var cameraRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height));
            Gizmos.color = Color.chartreuse;
            Gizmos.DrawRay(cameraRay);
            Gizmos.DrawWireSphere(cameraRay.origin + cameraRay.direction * interactDistance, interactRange);
        }
    }
}