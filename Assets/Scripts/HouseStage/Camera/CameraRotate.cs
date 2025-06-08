using HouseStage.Player;
using UnityEngine;

namespace HouseStage.Camera
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float lookBorders;

        private float _rotateAngle;

        private void Update()
        {
            SetRotation();
        }

        private void SetRotation()
        {
            _rotateAngle = Mathf.Clamp(_rotateAngle + playerInput.LookDirection().y * rotateSpeed * Time.deltaTime, -lookBorders, lookBorders);
            transform.rotation = Quaternion.Euler(-_rotateAngle, transform.parent.eulerAngles.y, 0);
        }
    }
}