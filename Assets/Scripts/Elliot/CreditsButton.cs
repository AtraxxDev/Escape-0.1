using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    [Header("Names On")]
    public GameObject Dev1;
    public GameObject Dev2;
    public GameObject Art1;
    public GameObject Art2;
    public GameObject Art;
    public GameObject Develop;

    [Header ("Names off")]
    public GameObject Dev11;
    public GameObject Dev22;
    public GameObject Art11;
    public GameObject Art22;

    public void TurnOn()
    {
        Dev11.SetActive(false);
        Dev22.SetActive(false);
        Art11.SetActive(false);
        Art22.SetActive(false);

        Dev1.SetActive(true);
        Dev2.SetActive(true);
        Art1.SetActive(true);
        Art2.SetActive(true);
        Art.SetActive(true);
        Develop.SetActive(true);
    }



}
