using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public TMP_Text timerText;
    private bool isTimerRunning = true;

    private void Start()
    {
        UpdateUIText();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        float timeRemaining = TimerManager.instance.GetTimeRemaining();
        TimerManager.instance.SetTimeRemaining(timeRemaining);

        UpdateUIText();
    }

    private void UpdateUIText()
    {
        float timeRemaining = TimerManager.instance.GetTimeRemaining();

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Detén el temporizador al cambiar de escena
        isTimerRunning = false;
    }
}
