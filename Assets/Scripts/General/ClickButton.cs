using General.Constants;
using UnityEngine;

namespace General
{
    public class ClickButton : MonoBehaviour
    {
        public void Click()
        {
            EventManager.Publish(Names.CLICK);
        }
    }
}