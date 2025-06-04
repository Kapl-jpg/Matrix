using Names;
using UnityEngine;

namespace HouseStage.Timer
{
    public class Timer : MonoBehaviour
    {
        public float CurrentSeconds { get; private set; }
        
        private void Start()
        {
            CurrentSeconds = Constants.TIME_IN_HOUSE;
        }

        private void Update()
        {
            CalculateTimer();
        }

        private void CalculateTimer()
        {
            CurrentSeconds = Mathf.Clamp(CurrentSeconds - Time.deltaTime, 0, Constants.TIME_IN_HOUSE);
            
            if (CurrentSeconds <= 0)
            {
                EventManager.Publish(EventNames.LoadNotebookScene);
            }
        }
    }
}
