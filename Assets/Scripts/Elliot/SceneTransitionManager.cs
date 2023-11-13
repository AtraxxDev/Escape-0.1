using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public bool isLobby;
    public bool isRoom;
    public FadeScreen fadeScreen;
    public OnAndOffObject on_off;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource soundAmbient;

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

        // Espera a que la nueva escena esté casi completamente cargada
        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        // Permite la activación de la nueva escena
        operation.allowSceneActivation = true;

    }
}
