using System.Collections;
using General.Constants;
using UnityEngine;

namespace MapStage.Days
{
    public class SkipDay : Subscriber
    {
        [SerializeField] private GameObject unclickableMask;
        [SerializeField] private float waitTime;
        
        [Event(Names.Map.WAIT_NEXT_DAY)]
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
            EventManager.Publish(Names.Map.DISABLE_POINT);
            EventManager.Publish(Names.Map.CLEAR_MAP);
            
            if (isLocked)
                EventManager.Publish(Names.Map.SHOW_LOCK_TEXT);
            
            unclickableMask.SetActive(true);
        }

        private void RebuildMap(bool isLocked)
        {
            EventManager.Publish(Names.Map.MARK_NEW_DAY);
            EventManager.Publish(Names.Map.REBUILD_MAP);
            
            if (isLocked)
                EventManager.Publish(Names.Map.HIDE_LOCK_TEXT);
            
            unclickableMask.SetActive(false);
        }
    }
}
