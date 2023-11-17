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
    }

    public void Activate1()
    {
        RandomNote.SetActive(true);
        Text.text = texts[1];
    }

    public void Activate2()
    {
        RandomNote.SetActive(true);
        Text.text = texts[2];
    }

    public void Activate3()
    {
        RandomNote.SetActive(true);
        Text.text = texts[3];
    }

    public void Activate4()
    {
        RandomNote.SetActive(true);
        Text.text = texts[4];
    }

    public void Activate5()
    {
        RandomNote.SetActive(true);
        Text.text = texts[5];
    }

    public void Activate6()
    {
        RandomNote.SetActive(true);
        Text.text = texts[6];
    }

    public void Activate7()
    {
        RandomNote.SetActive(true);
        Text.text = texts[7];
    }

    public void ActivateUwU()
    {
        RandomNote.SetActive(true);
        Text.text = texts[8];
    }

    public void ActivateUwU2()
    {
       RandomNote.SetActive(true) ;
       Text.text = texts[9];
    }

    public void ActivateUwU3()
    {
        RandomNote.SetActive(true);
        Text.text = texts[10];
    }

    public void ActivateGeneric0()
    {
        RandomNote.SetActive(true);
        Text.text = texts[11];
    }

    public void ActivateGeneric1()
    {
        RandomNote.SetActive(true);
        Text.text = texts[12];
    }
    public void ActivateGeneric2()
    {
        RandomNote.SetActive(true);
        Text.text = texts[13];   
    }


    public void Deactivate()
    {
        RandomNote.SetActive(!true);
    }
}
