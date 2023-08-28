using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomPW : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private string numerosaleatorios;

    // Start is called before the first frame update
    void Start()
    {
     
        numerosaleatorios += Random.Range(1, 9) + ", ";
        numerosaleatorios += Random.Range(1, 9) + ", ";
        numerosaleatorios += Random.Range(1, 9) + ", ";
        numerosaleatorios += Random.Range(1, 9) + ", ";

        Debug.Log("numerosaleatorios");

    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "" + numerosaleatorios;
    }
}
