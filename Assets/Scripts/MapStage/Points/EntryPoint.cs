using General.Save;
using Names;
using UnityEngine;

namespace MapStage.Points
{
    public class EntryPoint : Subscriber
    {
        [SerializeField] private GameObject entryButton;

        private PointData _currentPointData;

        [Event(EventNames.Map.EnablePoint)]
        private void ShowEntryPoint(PointData data)
        {
            entryButton.SetActive(true);
            _currentPointData = data;
        }
    
        [Event(EventNames.Map.DisablePoint)]
        private void HideEntryPoint()
        {
            entryButton?.SetActive(false);
        }
    
        public void EnterHouse()
        {
            if (_currentPointData.IsLocked)
            {
                EventManager.Publish(EventNames.Map.WaitNextDay,true);
                return;
            }
        
            SavePointName.SetName(_currentPointData.Name);
            EventManager.Publish(EventNames.Map.MarkNewDay);
            EventManager.Publish(EventNames.LoadHouseScene);
        }
    }
}
