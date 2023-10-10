using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 3;
    public Color fadeColor;
    public Renderer rend;
    public OnAndOffObject on_off;
    // Start is called before the first frame update
    void Start()
    {
        
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);

    }

    public void Fade(float alphaIn, float alphaOut)
    {

         StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
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
        Debug.Log("Me voy a apagar");
        on_off.ObjectOff();
        Debug.Log("Me apague");
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
    }
}
