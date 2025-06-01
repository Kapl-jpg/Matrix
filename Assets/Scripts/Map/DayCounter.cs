using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text dayCounterText;

    private int _dayNumber = 1;

    private void Start()
    {
        PrintDay();
    }

    public void NextDay()
    {
        _dayNumber++;
        PrintDay();
    }

    private void PrintDay()
    {
        dayCounterText.text = $"Δενό: {_dayNumber}";
    }
}

