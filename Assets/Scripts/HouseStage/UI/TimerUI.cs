using TMPro;
using UnityEngine;

namespace HouseStage.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Timer.Timer timer;
        [SerializeField] private TMP_Text timerText;
        
        private int _minutes;
        private int _seconds;
        
        private void Update()
        {
            var roundedSeconds = Mathf.RoundToInt(timer.CurrentSeconds);
            _minutes = roundedSeconds / 60;
            _seconds = roundedSeconds % 60;
            timerText.text = $"{_minutes}:{_seconds}";
        }
    }
}