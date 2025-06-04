using Names;
using UnityEngine;

namespace Map.Map
{
    public class MapLock : Subscriber
    {
        [SerializeField] private GameObject lockText;

        [Event(EventNames.Map.ShowLockText)] private void ShowLockText() => lockText.SetActive(true);
        [Event(EventNames.Map.HideLockText)] private void HideLockText() => lockText.SetActive(false);
    }
}