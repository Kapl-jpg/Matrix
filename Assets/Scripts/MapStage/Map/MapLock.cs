using General.Constants;
using UnityEngine;

namespace MapStage.Map
{
    public class MapLock : Subscriber
    {
        [SerializeField] private GameObject lockPanel;

        [Event(Names.Map.SHOW_LOCK_TEXT)] private void ShowLockText() => lockPanel.SetActive(true);
        [Event(Names.Map.HIDE_LOCK_TEXT)] private void HideLockText() => lockPanel.SetActive(false);
    }
}