using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public bool isLobby;
    public bool isRoom;
    public bool isWin;
    public bool isGameOver;
    public bool isDie;
    public FadeScreen fadeScreen;
    public OnAndOffObject on_off;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource soundAmbient;

    [Header("Win")]
    public AudioSource _soundWin1;
    public AudioSource _soundWin2;
    public GameObject _monster;
    [Header("Lose")]
    public AudioSource _soundLose1;
    public AudioSource _soundLose2;

    public void GoToSceneAsync(int sceneIndex)
    {
        on_off.ObjectOn();
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        Debug.Log("Inicio de la transición de escena");

        if (soundAmbient != null)
        {
            soundAmbient.Pause();
        }

        fadeScreen.FadeOut();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        // Verifica si es el lobby o la sala antes de iniciar la transición
        if (isRoom)
        {
            // Espera a que la pantalla esté completamente oscura
            while (fadeScreen.rend.material.color.a < 1)
            {
                yield return null;
            }

            Debug.Log("Pantalla oscura. Iniciando temporizador...");

            // Inicia el temporizador después de la transición en la sala
            TimerManager.instance.ResumeTimer();
        }
        else if (isLobby)
        {
            // Espera a que la pantalla esté completamente oscura
            while (fadeScreen.rend.material.color.a < 1)
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
            if(_monster != null) 
            {
                _monster.SetActive(false);
            }
            
            // Espera a que la pantalla esté completamente oscura
            while (fadeScreen.rend.material.color.a < 1)
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
            if (_monster != null)
            {
                _monster.SetActive(false);
            }
            // Espera a que la pantalla esté completamente oscura
            while (fadeScreen.rend.material.color.a < 1)
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
            while (fadeScreen.rend.material.color.a < 1)
            {
                yield return null;
            }

            TimerManager.instance.ResetTimer();

        }

        // Espera a que la nueva escena esté casi completamente cargada
        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        // Permite la activación de la nueva escena
        operation.allowSceneActivation = true;

    }
}
