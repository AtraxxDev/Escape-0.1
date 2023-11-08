using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCamController : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public AudioSource changeCamSound;

    public void SelectCam1()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        //changeCamSound.Play();
    }

    public void SelectCam2()
    {
        Cam1.SetActive(false);
        Cam2.SetActive(true);
        Cam3.SetActive(false);
        //changeCamSound.Play();
    }

    public void SelectCam3()
    {
        Cam1.SetActive(false);
        Cam2.SetActive(false);
        Cam3.SetActive(true);
        //changeCamSound.Play();
    }
}
