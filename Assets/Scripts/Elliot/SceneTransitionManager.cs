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
        if (soundAmbient != null)
        {
            soundAmbient.Pause();
        }
           
        fadeScreen.FadeOut();

        Debug.Log("Iniciare el cambio de escena");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

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
            yield return new WaitForSeconds(sound1.clip.length); // Espera a que el primer sonido termine y espera 1 segundo

            // Reproduce el segundo sonido
            sound2.Play();
            yield return new WaitForSeconds(sound2.clip.length +1.0f);

            // Reproduce el tercer sonido
            sound3.Play();
            yield return new WaitForSeconds(sound3.clip.length);
        }

        if (isRoom)
        {
            Debug.Log("Estoy en el Room");

            // Espera a que la pantalla esté completamente oscura
            while (fadeScreen.rend.material.color.a < 1)
            {
                Debug.Log("Estoy en el bucle");

                yield return null;
            }
            Debug.Log("Sali del bucle");
            
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
