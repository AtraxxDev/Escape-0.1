using System.Collections;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    private float elapsedTime;
    private float startTime;
    private float timeRemaining = 1200.0f;
    private float timeToNextMinute = 60.0f;
    public float timeScale = 1.0f;
    public AudioClip finishsound;

    [SerializeField] private float initialTime = 1200.0f;
    public AudioClip minuteSound;

    private AudioSource audioSource;

    public bool IsTimerRunning { get; private set; } = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        //gameManager = FindObjectOfType<GameManager>(); // Busca el GameManager en la escena
    }

    private void Start()
    {
        timeRemaining = initialTime;
        startTime = Time.time;
    }

    private void Update()
    {
        if (IsTimerRunning && timeRemaining > 0f)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        elapsedTime = Time.time - startTime;
        timeRemaining = Mathf.Max(0f, initialTime - elapsedTime * timeScale);

        if (elapsedTime >= timeToNextMinute)
        {
            PlaySoundOnMinuteChange();
            HandleMinuteEvents();
            timeToNextMinute += 60.0f;
        }

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            HandleTimerZeroLogic();
        }
    }

    private void PlaySoundOnMinuteChange()
    {
        audioSource.PlayOneShot(minuteSound);
    }

    private void HandleMinuteEvents()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);

        if (minutes == 19)
        {
            Debug.Log("Evento para 1 minuto restante");
        }
        else if (minutes == 15)
        {
            Debug.Log("Evento para 5 minutos restantes");
        }
        else if (minutes == 10)
        {
            Debug.Log("Evento para 10 minutos restantes");
        }
        else if (minutes == 5)
        {
            Debug.Log("Evento para 15 minutos restantes");
        }
    }

    private void HandleTimerZeroLogic()
    {
        Debug.Log("Temporizador llegó a cero. Manejando lógica de final de juego.");
        StartCoroutine(FinishEvent());
    }

    IEnumerator FinishEvent()
    {
        audioSource.PlayOneShot(finishsound);
        yield return new WaitForSeconds(10);
        //.GameOver();
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public void SetTimeRemaining(float time)
    {
        timeRemaining = time;
    }

    public void PauseTimer()
    {
        IsTimerRunning = false;
    }

    public void ResumeTimer()
    {
        IsTimerRunning = true;
        startTime = Time.time - (initialTime - timeRemaining) / timeScale;
    }

    public void ResetTimer()
    {
        IsTimerRunning = true;
        startTime = Time.time;
        timeToNextMinute = 60.0f;
        timeRemaining = initialTime;
    }











}
