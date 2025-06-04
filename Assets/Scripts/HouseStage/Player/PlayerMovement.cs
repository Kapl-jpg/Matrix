using UnityEngine;

namespace HouseStage.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Rigidbody rb;
        
        [SerializeField] private float walkSpeed;
        [SerializeField] private float sprintSpeed;
        [SerializeField] private float rotateSpeed;
        
        private Vector2 _direction;
        private float _rotate;

        private void Update()
        {
            _direction = playerInput.MoveDirection();

            SetRotation();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 move = new Vector3(_direction.x, 0, _direction.y);
            move = transform.TransformDirection(move);
            rb.linearVelocity = new Vector3(
                move.x * Speed(),
                rb.linearVelocity.y,
                move.z * Speed());
        }

        private void SetRotation()
        {
            _rotate += playerInput.LookDirection().x * rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, _rotate, 0);
        }

        private float Speed()
        {
            return playerInput.Sprint() ? sprintSpeed : walkSpeed;
        }
    }
}