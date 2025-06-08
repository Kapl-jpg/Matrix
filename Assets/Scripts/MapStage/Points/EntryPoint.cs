using General.Constants;
using General.Save;
using UnityEngine;

namespace MapStage.Points
{
    public class EntryPoint : Subscriber
    {
        [SerializeField] private GameObject entryButton;

        private PointData _currentPointData;

        [Event(Names.Map.ENABLE_POINT)]
        private void ShowEntryPoint(PointData data)
        {
            entryButton.SetActive(true);
            _currentPointData = data;
        }
    
        [Event(Names.Map.DISABLE_POINT)]
        private void HideEntryPoint()
        {
            entryButton?.SetActive(false);
        }
    
        public void EnterHouse()
        {
            if (_currentPointData.IsLocked)
            {
                EventManager.Publish(Names.Map.WAIT_NEXT_DAY,true);
                return;
            }
        
            SavePointName.SetName(_currentPointData.Name);
            EventManager.Publish(Names.Map.MARK_NEW_DAY);
            EventManager.Publish(Names.LOAD_HOUSE_SCENE);
        }
    }
}
