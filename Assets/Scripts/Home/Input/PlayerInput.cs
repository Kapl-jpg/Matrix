using UnityEngine;

namespace Home.Input
{
    public class PlayerInput : MonoBehaviour
    {
        private InputSystem_Actions _action;

        private void Start()
        {
            _action = new InputSystem_Actions();
            _action.Player.Enable();
        }

        private void OnDestroy()
        {
            _action.Player.Disable();
        }

        public Vector2 MoveDirection() => _action.Player.Move.ReadValue<Vector2>();
        public Vector2 LookDirection() => _action.Player.Look.ReadValue<Vector2>();
        public bool Sprint() => _action.Player.Sprint.IsPressed();
        public bool Interact() => _action.Player.Interact.triggered;
    }
}