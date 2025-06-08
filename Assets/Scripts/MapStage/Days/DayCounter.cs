using General.Constants;
using General.Save;
using TMPro;
using UnityEngine;

namespace MapStage.Days
{
    public class DayCounter : Subscriber
    {
        [SerializeField] private TMP_Text dayCounterText;

        private int _dayNumber = 1;

        private void Start()
        {
            _dayNumber = SaveDay.CurrentDay;
            PrintDay();
        }

        [Event(Names.Map.MARK_NEW_DAY)]
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

