using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    // Variables Scene Transition
    [Header("Scene Transition")]
    

    public bool isLobby;
    public bool isRoom;
    public bool isWin;
    public bool isGameOver;
    public bool isDie;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource soundAmbient;

    [Header("Win")]
    public AudioSource _soundWin1;
    public AudioSource _soundWin2;
    //public GameObject _monster;
    [Header("Lose")]
    public AudioSource _soundLose1;
    public AudioSource _soundLose2;

    // Variable timer manager
    private float elapsedTime;
    private float startTime;
    private float timeRemaining = 1200.0f;
    private float timeToNextMinute = 60.0f;
    [Header("Timer Manager")]
    public float timeScale = 1.0f;
    public AudioClip finishsound;
    private bool timerStarted = false;
    [SerializeField] private float initialTime = 1200.0f;
    public AudioClip minuteSound;

    private AudioSource audioSource;

    public bool IsTimerRunning { get; private set; } = false;

    [Header("Game")]
    // Variables Game
    private int WinScene = 7;
    private int GameoverScene = 6;
    public Inventory _inventory;

    //Variables On and off object

    [Header("On and Off")]

    public GameObject _object;
    [SerializeField] private bool isFadeEncountered = false;
    [SerializeField] private bool isMainEncountered = false;




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

    // Timer Manager
    private void Start()
    {
       
    }

    private void Update()
    {
        if (IsTimerRunning && timeRemaining > 0f)
        {
            UpdateTimer();
        }

        // Solo realiza la búsqueda si _object es nulo y aún no se ha encontrado la cámara
        if (_object == null && !isFadeEncountered)
        {
            findObject();
        }

        // Solo realiza la búsqueda si _object es nulo y aún no se ha encontrado la cámara
        if (FadeScreen.instance == null && !isMainEncountered)
        {
            FindAndAssignFadeScreen();
        }

    }


    private void StartTimer()
    {
        if (!timerStarted)
        {
            timeRemaining = initialTime;
            startTime = Time.time;
            timerStarted = true;
            IsTimerRunning = true;
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
        GameOver();
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

    // Game

    public void WinGame()
    {
        isRoom = false;
        isWin = true;
        GoToSceneAsync(WinScene);
        PlayerPrefs.DeleteAll();
        
    }

    public void GameOver()
    {
        isRoom = false;
        isGameOver = true;
        _inventory.ClearKeys();
        GoToSceneAsync(GameoverScene);
        PlayerPrefs.DeleteAll();
    }

    // Scene Transition 

    private void FindAndAssignFadeScreen()
    {
       

        if (FadeScreen.instance == null)
        {
            GameObject fadeScreenObject = GameObject.FindGameObjectWithTag("MainCamera");

            FadeScreen.instance = fadeScreenObject.GetComponent<FadeScreen>();


            if (FadeScreen.instance != null)
            {
                isMainEncountered = true;
                Debug.Log("Encontre la MainCamera");
            }
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta '" + "MainCamera" + "'.");
        }
    }

    public void GoToSceneAsync(int sceneIndex)
    {
        ObjectOn();
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        Debug.Log("Inicio de la transición de escena");

        if (soundAmbient != null)
        {
            soundAmbient.Pause();
        }

        FadeScreen.instance.FadeOut();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        // Verifica si es el lobby o la sala antes de iniciar la transición
        if (isRoom)
        {
            // Espera a que la pantalla esté completamente oscura
            while (FadeScreen.instance.rend.material.color.a < 1)
            {
                yield return null;
            }


            Debug.Log("Pantalla oscura. Iniciando temporizador...");

            // Inicia el temporizador después de la transición en la sala
            ResumeTimer();
        }
        else if (isLobby)
        {
            // Espera a que la pantalla esté completamente oscura
            while (FadeScreen.instance.rend.material.color.a < 1)
            {
                yield return null;
            }


            // Reproduce el primer sonido
            sound1.Play();
            yield return new WaitForSeconds(sound1.clip.length);


            yield return new WaitForSeconds(1.0f);

            // Reproduce el segundo sonido
            sound2.Play();
            yield return new WaitForSeconds(sound2.clip.length + 1.0f);


            // Reproduce el tercer sonido
            sound3.Play();
            yield return new WaitForSeconds(sound3.clip.length);

        }

        else if (isWin)
        {
            /*if (_monster != null)
            {
                _monster.SetActive(false);
            }*/

            // Espera a que la pantalla esté completamente oscura
            while (FadeScreen.instance.rend.material.color.a < 1)
            {
                yield return null;
            }


            // Reproduce el primer sonido
            _soundWin1.Play();
            yield return new WaitForSeconds(_soundWin1.clip.length);


            yield return new WaitForSeconds(1.0f);

            // Reproduce el segundo sonido
            _soundWin2.Play();
            yield return new WaitForSeconds(_soundWin2.clip.length + 1.0f);


        }

        else if (isGameOver)
        {
            /*if (_monster != null)
            {
                _monster.SetActive(false);
            }*/
            // Espera a que la pantalla esté completamente oscura
            while (FadeScreen.instance.rend.material.color.a < 1)
            {
                yield return null;
            }

            // Reproduce el primer sonido
            _soundLose1.Play();
            yield return new WaitForSeconds(_soundLose1.clip.length);


            yield return new WaitForSeconds(1.0f);

            // Reproduce el segundo sonido
            _soundLose2.Play();
            yield return new WaitForSeconds(_soundLose2.clip.length + 1.0f);

        }

        else if (isDie)
        {
            // Espera a que la pantalla esté completamente oscura
            while (FadeScreen.instance.rend.material.color.a < 1)
            {
                yield return null;
            }

            ResetTimer();

        }

        // Espera a que la nueva escena esté casi completamente cargada
        while (operation.progress < 0.9f)
        {
            yield return null;
        }
        if (timerStarted == false)  // Verifica si no se ha iniciado el temporizador
        {
            StartTimer();
            Debug.Log("Pantalla oscura. Iniciando temporizador...");
        }



        // Permite la activación de la nueva escena
        operation.allowSceneActivation = true;
        isFadeEncountered = false;
        isMainEncountered = false;

        if (IsTimerRunning == false)
        {
            Debug.Log("Estaba en pausa");
            ResumeTimer();
        }

    }

    // Object on adn Off

    public void ObjectOn()
    {
        if (_object != null)
        {
            _object.SetActive(true);
        }
        else
        {
            Debug.LogWarning("El objeto de referencia es nulo en ObjectOn().");
        }
    }

    public void ObjectOff()
    {
        if (_object != null)
        {
            _object.SetActive(false);
        } 
        else
        {
            Debug.LogWarning("El objeto de referencia es nulo en ObjectOff().");
        }
    }

    public void findObject()
    {
        if (_object == null)
        {
            // Encuentra el primer objeto con la etiqueta "MainCamera"
            GameObject cameraObject = GameObject.FindGameObjectWithTag("FadeCamera");

            if (cameraObject != null)
            {
                // Asigna el objeto encontrado a la variable _object
                _object = cameraObject;
                isFadeEncountered = true;
                Debug.Log("Encontre el fadeCamera");
            }
            else
            {
                Debug.LogWarning("No se encontró ningún objeto con la etiqueta 'FadeCamera'.");
            }
        }
    }

    //Scene Status
    public void SetIsLobby(bool value)
    {
        isLobby = value;
    }

    public void SetIsRoom(bool value)
    {
        isRoom = value;
    }

    public void SetIsWin(bool value)
    {
        isWin = value;
    }

    public void SetIsGameOver(bool value)
    {
        isGameOver = value;
    }

    public void SetIsDie(bool value)
    {
        isDie = value;
    }

}
