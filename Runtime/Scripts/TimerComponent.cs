using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour
{
    public float countdownTime;
    public bool loop;

    public TextMeshProUGUI displayText;

    public int RemainingMinutes => Mathf.FloorToInt(countdownTime / 60);
    public int RemainingSeconds => Mathf.FloorToInt(countdownTime % 60);

    public UnityEvent onElapsed;

    private float _startingCountdown;

    private void Awake()
    {
        _startingCountdown = countdownTime;
    }

    private void Update()
    {
        displayText.text = string.Format(
            "{0:00}:{1:00}",
            RemainingMinutes,
            RemainingSeconds);

        if (countdownTime > 0) {
            countdownTime -= Time.deltaTime;
            return;
        }

        onElapsed.Invoke();

        if (loop) {
            countdownTime = _startingCountdown;
        } else {
            countdownTime = 0;
        }
    }
}
