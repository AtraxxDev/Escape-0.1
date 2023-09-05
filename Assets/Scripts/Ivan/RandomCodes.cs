using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomCodes : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    public string numerosaleatorios;

    // Start is called before the first frame update
    void Start()
    {

        numerosaleatorios += Random.Range(1, 9) + "";
        numerosaleatorios += Random.Range(1, 9) + "";
        numerosaleatorios += Random.Range(1, 9) + "";
        numerosaleatorios += Random.Range(1, 9) + "";

        

        Text.text = "" + numerosaleatorios;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
