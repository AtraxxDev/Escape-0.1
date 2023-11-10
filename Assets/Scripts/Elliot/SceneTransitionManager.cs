using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public bool isLobby;
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
        soundAmbient.Pause();
        fadeScreen.FadeOut();
        if (isLobby)
        {
            Debug.Log("Estoy en el lobby");

            // Espera a que la pantalla esté completamente oscura
            while (fadeScreen.rend.material.color.a < 1)
            {
                Debug.Log("Estoy en el bucle");

                yield return null;
            }
            Debug.Log("Sali del bucle");
            // Reproduce el primer sonido
            sound1.Play();
            yield return new WaitForSeconds(sound1.clip.length + 1.0f); // Espera a que el primer sonido termine y espera 1 segundo

            // Reproduce el segundo sonido
            sound2.Play();
            yield return new WaitForSeconds(sound2.clip.length +1.0f);

            // Reproduce el tercer sonido
            sound3.Play();
            yield return new WaitForSeconds(sound2.clip.length);
        }

        Debug.Log("Iniciare el cambio de escena");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        // Espera a que la nueva escena esté casi completamente cargada
        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        // Permite la activación de la nueva escena
        operation.allowSceneActivation = true;
        }
    }
