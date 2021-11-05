using UnityEngine;
using UnityAtoms.BaseAtoms;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private FloatVariable elapsedTime;
    [SerializeField] private TMP_Text timerText;

    public void UpdateTimerText(float value)
    {
        int seconds = (int)value % 60;
        int minutes = (int)value / 60;
        string time = minutes + ":" + seconds.ToString("00");
        timerText.text = time;
    }
}
