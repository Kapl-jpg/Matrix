using Names;
using UnityEngine;

namespace MapStage.Map
{
    public class MapLock : Subscriber
    {
        [SerializeField] private GameObject lockPanel;

        [Event(EventNames.Map.ShowLockText)] private void ShowLockText() => lockPanel.SetActive(true);
        [Event(EventNames.Map.HideLockText)] private void HideLockText() => lockPanel.SetActive(false);
    }
}