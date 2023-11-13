using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    private float elapsedTime; // Agrega esta línea
    private float startTime;
    private float timeRemaining = 1200.0f; // 20 minutos en segundos
    private float timeToNextMinute = 60.0f; // tiempo para el próximo minuto
    public float timeScale = 1.0f; // Factor de escala para ajustar la velocidad del temporizador
    public AudioClip finishsound;
    [SerializeField] private float initialTime = 1200.0f; // Tiempo inicial en segundos, se muestra en el inspector

    public AudioClip minuteSound; // Sonido para cada minuto
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
    }

    private void Start()
    {
        // Establece el tiempo inicial como initialTime desde el inspector
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
        timeRemaining = Mathf.Max(0f, initialTime - elapsedTime * timeScale); // Ajustar la velocidad del temporizador

        if (elapsedTime >= timeToNextMinute)
        {
            PlaySoundOnMinuteChange();
            HandleMinuteEvents();
            timeToNextMinute += 60.0f;
        }

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            HandleTimerZeroLogic(); // Maneja la lógica cuando el temporizador llega a cero
        }
    }

    private void PlaySoundOnMinuteChange()
    {
        audioSource.PlayOneShot(minuteSound);
    }

    private void HandleMinuteEvents()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);

        // Agrega eventos según los minutos restantes

        if (minutes == 19)
        {
            // Evento para 1 minuto restante
            Debug.Log("Evento para 1 minuto restante");
        }

        else if (minutes == 15)
        {
            // Evento para 5 minutos restantes
            Debug.Log("Evento para 5 minutos restantes");
        }
        else if (minutes == 10)
        {
            // Evento para 10 minutos restantes
            Debug.Log("Evento para 10 minutos restantes");
        }
        else if (minutes == 5)
        {
            // Evento para 15 minutos restantes
            Debug.Log("Evento para 15 minutos restantes");
        }
    }

    private void HandleTimerZeroLogic()
    {
        // Maneja la lógica cuando el temporizador llega a cero (por ejemplo, fin del juego).
        Debug.Log("Temporizador llegó a cero. Manejando lógica de final de juego.");
        audioSource.PlayOneShot(finishsound);
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
}
