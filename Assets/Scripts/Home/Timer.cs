using Names;
using UnityEngine;

namespace Home
{
    public class Timer : MonoBehaviour
    {
        public float CurrentSeconds { get; private set; }
        
        private void Start()
        {
            CurrentSeconds = Constants.HOME_SECONDS;
        }

        private void Update()
        {
            CalculateTimer();
        }

        private void CalculateTimer()
        {
            CurrentSeconds = Mathf.Clamp(CurrentSeconds - Time.deltaTime, 0, Constants.HOME_SECONDS);
            
            if (CurrentSeconds <= 0)
            {
                EventManager.Publish(EventNames.LoadNotebook);
            }
        }
    }
}
