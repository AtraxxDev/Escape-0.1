using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPart_Controller : MonoBehaviour
{
    public Inventory _inventory;

    // Start is called before the first frame update
    public GameObject Part1;
    public GameObject Part2;
    public GameObject Part3;
    public GameObject Part4;
    public AudioSource ObtainedSound;

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

    public void AddInventoryPart()
    {
        _inventory.Key1 = true;
        ObtainedSound.Play();
        Part1.SetActive(false);
    }

    public void AddInventoryPart2()
    {
        _inventory.Key2 = true;
        ObtainedSound.Play();
        Part2.SetActive(false);

    }

    public void AddInventoryPart3()
    {
        _inventory.Key3 = true;
        ObtainedSound.Play();
        Part3.SetActive(false);

    }

    public void AddInventoryPart4()
    {
        _inventory.Key4 = true;
        ObtainedSound.Play();
        Part4.SetActive(false);

    }

}
