using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPart_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Part1;
    public GameObject Part1_Contention;

    public GameObject Part2;
    public GameObject Part2_Contention;

    public GameObject Part3;
    public GameObject Part3_Contention;

    public GameObject Part4;
    public GameObject Part4_Contention;
    public AudioSource ObtainedSound;

    public void AddInventoryPart()
    {
        Part1.SetActive(false);
        Part1_Contention.SetActive(true);
        ObtainedSound.Play();
    }

    public void AddInventoryPart2()
    {
        Part2.SetActive(false);
        Part2_Contention.SetActive(true);
        ObtainedSound.Play();
    }
    public void AddInventoryPart3()
    {
        Part3.SetActive(false);
        Part3_Contention.SetActive(true);
        ObtainedSound.Play();
    }
    public void AddInventoryPart4()
    {
        Part4.SetActive(false);
        Part4_Contention.SetActive(true);
        ObtainedSound.Play();
    }

}
