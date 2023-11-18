using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notas_Yeah : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    [SerializeField] private TMP_Text Text2;
    [SerializeField] private string[] texts;
    public GameObject RandomNote;


    public void Activate0()
    {
        RandomNote.SetActive(true);
        Text.text = texts[0];
        ResizeText();

    }

    public void Activate1()
    {
        RandomNote.SetActive(true);
        Text.text = texts[1];
        ResizeText();

    }

    public void Activate2()
    {
        RandomNote.SetActive(true);
        Text.text = texts[2];
        ResizeText();

    }

    public void Activate3()
    {
        RandomNote.SetActive(true);
        Text.text = texts[3];
        ResizeText();

    }

    public void Activate4()
    {
        RandomNote.SetActive(true);
        Text.text = texts[4];
        ResizeText();

    }

    public void Activate5()
    {
        RandomNote.SetActive(true);
        Text.text = texts[5];
        ResizeText();

    }

    public void Activate6()
    {
        RandomNote.SetActive(true);
        Text.text = texts[6];
        ResizeText();

    }

    public void Activate7()
    {
        RandomNote.SetActive(true);
        Text.text = texts[7];
        ResizeText();

    }

    public void ActivateUwU()
    {
        RandomNote.SetActive(true);
        Text.text = texts[8];
        ResizeText();

    }

    public void ActivateUwU2()
    {
       RandomNote.SetActive(true) ;
       Text.text = texts[9];
        ResizeText();

    }

    public void ActivateUwU3()
    {
        RandomNote.SetActive(true);
        Text.text = texts[10];
        ResizeText();

    }

    public void ActivateGeneric0()
    {
        RandomNote.SetActive(true);
        Text.text = texts[11];
        ResizeText();

    }

    public void ActivateGeneric1()
    {
        RandomNote.SetActive(true);
        Text.text = texts[12];
        ResizeText();

    }
    public void ActivateGeneric2()
    {
        RandomNote.SetActive(true);
        Text.text = texts[13];   
        ResizeText();
    }


    public void Deactivate()
    {
        RandomNote.SetActive(!true);
    }


    private void ResizeText()
    {
        Text.fontSize = 30; 
        Text.rectTransform.sizeDelta = new Vector2(200, 50);
    }

}
