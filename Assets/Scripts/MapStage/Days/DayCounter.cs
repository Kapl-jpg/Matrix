using General.Save;
using Names;
using TMPro;
using UnityEngine;

namespace MapStage.Days
{
    public class DayCounter : Subscriber
    {
        [SerializeField] private TMP_Text dayCounterText;

        private int _dayNumber;

        private void Start()
        {
            _dayNumber = SaveDay.CurrentDay;
            PrintDay();
        }

        [Event(EventNames.Map.MarkNewDay)]
        private void MarkNewDay()
        {
            _dayNumber++;
            SaveDay.SetDay(_dayNumber);
            PrintDay();
        }

        private void PrintDay()
        {
            dayCounterText.text = $"День: {_dayNumber}";
        }
    }
}

