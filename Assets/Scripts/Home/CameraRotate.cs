using Home.Input;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float lookBoreders;

    private float _rotate;

    private void Update()
    {
        SetRotation();
    }

    private void SetRotation()
    {
        _rotate = Mathf.Clamp(_rotate + playerInput.LookDirection().y * rotateSpeed * Time.deltaTime, -lookBoreders, lookBoreders);
        transform.rotation = Quaternion.Euler(-_rotate, transform.parent.eulerAngles.y, 0);
    }
}