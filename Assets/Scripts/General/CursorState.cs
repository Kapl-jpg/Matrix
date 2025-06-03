using Enums;
using UnityEngine;

namespace General
{
    public class CursorState : MonoBehaviour
    {
        [SerializeField] private CursorType cursorType;

        private void Start()
        {
            SetCursor(cursorType);
        }

        private void SetCursor(CursorType type)
        {
            if (type == CursorType.Locked)
                Cursor.lockState = CursorLockMode.Locked;

            if (type == CursorType.Free)
                Cursor.lockState = CursorLockMode.None;
        }
    }
}
