using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPW : MonoBehaviour
{
    //[SerializeField] private TMP_Text Text;
    public GameObject CaptainLogObj;

    public string codigoAsignado; // Nuevo campo para el código asignado

    // Este método se llama al inicio para asignar un código específico.
    public void AsignarCodigo(string codigo)
    {
        codigoAsignado = codigo;
       // Text.text = codigoAsignado;
    }
    void Start()
    {

        codigoAsignado += Random.Range(1, 9) + "";
        codigoAsignado += Random.Range(1, 9) + "";
        codigoAsignado += Random.Range(1, 9) + "";
        codigoAsignado += Random.Range(1, 9) + "";


        AsignarCodigo(codigoAsignado);
        Debug.Log(" " + codigoAsignado);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
