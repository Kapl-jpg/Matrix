using System.Collections;
using Names;
using UnityEngine;

namespace Map
{
    public class SkipDay : Subscriber
    {
        [SerializeField] private GameObject unclickableMask;
        [SerializeField] private float waitTime;
        
        [Event(EventNames.Map.WaitNextDay)]
        public void WaitNextDay(bool isLocked)
        {
            StartCoroutine(Wait(isLocked));
        }

        private IEnumerator Wait(bool isLocked)
        {
            ClearMap(isLocked);
            yield return new WaitForSeconds(waitTime);
            RebuildMap(isLocked);
        }

        private void ClearMap(bool isLocked)
        {
            EventManager.Publish(EventNames.Map.DisablePoint);
            EventManager.Publish(EventNames.Map.ClearMap);
            
            if (isLocked)
                EventManager.Publish(EventNames.Map.ShowLockText);
            
            unclickableMask.SetActive(true);
        }

        private void RebuildMap(bool isLocked)
        {
            EventManager.Publish(EventNames.Map.MarkNewDay);
            EventManager.Publish(EventNames.Map.RebuildMap);
            
            if (isLocked)
                EventManager.Publish(EventNames.Map.HideLockText);
            
            unclickableMask.SetActive(false);
        }
    }
}
