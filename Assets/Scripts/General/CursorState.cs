using UnityEngine;

namespace Home
{
    public class CursorState : MonoBehaviour
    {
        [SerializeField] private CursorType cursorType;
        private enum CursorType
        {
            Locked,
            Free
        }
        
        void Start()
        {
            if (cursorType == CursorType.Locked)
                Cursor.lockState = CursorLockMode.Locked;
            
            if(cursorType == CursorType.Free) 
                Cursor.lockState = CursorLockMode.None;
        }
    }
}
