using General;
using General.Constants;
using Interfaces;
using UnityEngine;

namespace HouseStage.Player
{
    public class PlayerItemDetection : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private float interactRange;
        [SerializeField] private float interactDistance;

        [SerializeField] private LayerMask interactMask;

        private IInteractable _interactable;
        private UnityEngine.Camera _mainCamera;

        private void Start()
        {
            _mainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            var ray = _mainCamera.ScreenPointToRay(new Vector3(Screen.width, Screen.height) / 2);

            var isInteractableObject =
                Physics.SphereCast(ray, interactRange, out RaycastHit hit, interactDistance, interactMask);

            if (isInteractableObject)
            {
                if (_interactable == null)
                {
                    hit.collider.TryGetComponent(out IInteractable interactable);
                    EventManager.Publish(Names.House.SHOW_ITEM_DESCRIPTION, interactable.Type);
                    _interactable = interactable;
                }
            }
            else
            {
                if (_interactable!=null)
                {
                    EventManager.Publish(Names.House.HIDE_ITEM_DESCRIPTION);
                    _interactable = null;
                }
            }

            if (!playerInput.Interact()) return;
            _interactable?.Interact();
        }
    }
}