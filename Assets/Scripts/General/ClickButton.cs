using Names;
using UnityEngine;

namespace General
{
    public class ClickButton : MonoBehaviour
    {
        public void Click()
        {
            EventManager.Publish(EventNames.Click);
        }
    }
}