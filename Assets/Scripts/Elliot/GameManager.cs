using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public AudioSource soundWater;

    // Variables Scene Transition
    [Header("Scene Transition")]
    

    public bool isLobby;
    public bool isRoom;
    public bool isWin;
    public bool isGameOver;
    public bool isDie;
    public bool isFinish;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource soundAmbient;

    private string nextsceneName;

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
    private int GameoverScene = 7;
    public Inventory _inventory;

    //Variables On and off object

    [Header("Monster")]
    public AudioSource breathingPlayer;
    public AudioSource sreamerSound;
    private GameObject _Monster;
    [SerializeField] private bool isMonsterEncountered = false;


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
        if (_Monster == null && !isMonsterEncountered)
        {
            Debug.Log("Buscare al mounstro");
            findMonster();
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
        //soundWater.Stop();
        audioSource.PlayOneShot(finishsound);
        yield return new WaitForSeconds(2);
        breathingPlayer.Play();
        yield return new WaitForSeconds(7);
        breathingPlayer.Stop();
        ActivateMonster();
        sreamerSound.Play();
        yield return new WaitForSeconds(0.5f);
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
    IsTimerRunning = false;
    isGameOver = false;
    timerStarted = false;
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
        nextsceneName = SceneManager.GetSceneByBuildIndex(sceneIndex).name;

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

        else if (isFinish)
        {
            // Espera a que la pantalla esté completamente oscura
            while (FadeScreen.instance.rend.material.color.a < 1)
            {
                yield return null;
            }

            
        }


        // Espera a que la nueva escena esté casi completamente cargada
        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        if (nextsceneName == "HandLvl1" && timerStarted == false)
        {
            StartTimer();
            Debug.Log("Pantalla oscura. Iniciando temporizador...");
        }



        // Permite la activación de la nueva escena
        operation.allowSceneActivation = true;
        isFadeEncountered = false;
        isMainEncountered = false;
        isMonsterEncountered = false;

        /*if (IsTimerRunning == false)
        {
            Debug.Log("Estaba en pausa");
            ResumeTimer();
        }*/

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

    // Monster
    public void findMonster()
    {
        Debug.Log("Find Monster");
        if (_Monster == null)
        {
            // Encuentra el primer objeto con la etiqueta "MainCamera"
            GameObject monsterObject = GameObject.FindGameObjectWithTag("Monster");

            if (monsterObject != null)
            {
                // Asigna el objeto encontrado a la variable _object
                _Monster = monsterObject;
                isMonsterEncountered = true;
                Debug.Log("Encontre al mounstro");
            }
            else
            {
                Debug.LogWarning("No se encontró ningún objeto con la etiqueta 'Monster'.");
            }
        }
    }

    private void ActivateMonster()
    {
        if (_Monster != null)
        {
            _Monster.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Activando el monstruo.");
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

    public void SetIsFinish(bool value)
    {
        isFinish = value;
    }

}
