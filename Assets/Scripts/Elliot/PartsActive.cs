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
    private void Awake()
    {
        // Busca el objeto con la etiqueta "InventoryObject" en la escena
        GameObject inventoryObject = GameObject.FindWithTag("InventoryObject");

        // Asegúrate de que se encontró el objeto
        if (inventoryObject != null)
        {
            // Obtiene el componente Inventory del objeto encontrado
            _inventory = inventoryObject.GetComponent<Inventory>();
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta 'InventoryObject' en la escena.");
        }

      

    }

    private void Start()
    {
        if (_inventory.Key1 == true)
        {
            Part1.SetActive(true);
        }
        else
        {
            Part1.SetActive(false);

        }

        if (_inventory.Key2 == true)
        {
            Part2.SetActive(true);
        }
        else
        {
            Part2.SetActive(false);

        }

        if (_inventory.Key3 == true)
        {
            Part3.SetActive(true);
        }
        else
        {
            Part3.SetActive(false);

        }

        if (_inventory.Key4 == true)
        {
            Part4.SetActive(true);
        }
        else
        {
            Part4.SetActive(false);

        }

    }
}
