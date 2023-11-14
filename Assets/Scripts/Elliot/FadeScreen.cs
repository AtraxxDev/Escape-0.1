using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public static FadeScreen instance;

    public bool fadeOnStart = true;
    public float fadeDuration = 3;
    public Color fadeColor;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
       
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeRoutine(1, 0, () =>
        {
            Debug.Log("Me voy a apagar");
            GameManager.instance.ObjectOff();
            Debug.Log("Me apague");
            // Agrega el código que deseas ejecutar después de la transición de fade aquí
        }));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeRoutine(0, 1, () =>
        {
            // Agrega el código que deseas ejecutar después de la transición de fade aquí
        }));

    }

    public void Fade(float alphaIn, float alphaOut, System.Action callback)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut, callback));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut, System.Action callback)
    {
        float timer = 0;
        while (timer <= fadeDuration) 
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn,alphaOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
        callback?.Invoke(); // Invoca la función de devolución de llamada si no es nula
    }
}
