using UnityEngine;

namespace Home
{
    public class CursorState : MonoBehaviour
    {
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
