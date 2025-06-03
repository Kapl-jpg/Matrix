using General.Save;
using TMPro;
using UnityEngine;

namespace Map
{
    public class DayCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text dayCounterText;

        private int _dayNumber;

        private void Start()
        {
            _dayNumber = SaveDay.CurrentDay;
            PrintDay();
        }

        public void NextDay()
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

