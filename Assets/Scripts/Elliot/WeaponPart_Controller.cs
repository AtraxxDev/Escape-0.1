using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPart_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Part1;
    public AudioSource ObtainedSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventoryPart()
    {
        Part1.SetActive(false);
        ObtainedSound.Play();
    }

}
