using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsActive : MonoBehaviour
{
    public Inventory _inventory;
    public GameObject Part1;
    public GameObject Part2;
    public GameObject Part3;
    public GameObject Part4;

    public GameObject Taser1;


    public Animator victoryAnimator;  // Referencia al componente Animator para la animaci�n de victoria
    public AudioSource victorySound;  // Referencia al componente AudioSource para el sonido de victoria

    private void Awake()
    {
        // Busca el objeto con la etiqueta "InventoryObject" en la escena
        GameObject inventoryObject = GameObject.FindWithTag("InventoryObject");

        // Aseg�rate de que se encontr� el objeto
        if (inventoryObject != null)
        {
            // Obtiene el componente Inventory del objeto encontrado
            _inventory = inventoryObject.GetComponent<Inventory>();
        }
        else
        {
            Debug.LogError("No se encontr� ning�n objeto con la etiqueta 'InventoryObject' en la escena.");
        }
    }

    private void Start()
    {
        UpdateParts();
    }

    private void UpdateParts()
    {
        // Actualiza el estado de las partes seg�n las llaves en el inventario
        Part1.SetActive(_inventory.Key1);
        Part2.SetActive(_inventory.Key2);
        Part3.SetActive(_inventory.Key3);
        Part4.SetActive(_inventory.Key4);

        // Verifica si todas las llaves est�n en true
        if (_inventory.Key1 && _inventory.Key2 && _inventory.Key3 && _inventory.Key4)
        {
            // Si todas las llaves est�n en true, activa la animaci�n y reproduce el sonido de victoria
            PlayVictoryAnimationAndSound();
            Taser1.SetActive(true);
        }
    }

    private void PlayVictoryAnimationAndSound()
    {
        // Activa la animaci�n de victoria
        if (victoryAnimator != null)
        {
            victoryAnimator.SetBool("OpenFor", true);
        }

        // Reproduce el sonido de victoria
        if (victorySound != null)
        {
            victorySound.Play();
        }
    }
}
