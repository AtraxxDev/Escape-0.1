using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPW : MonoBehaviour
{
    //[SerializeField] private TMP_Text Text;
    public GameObject CaptainLogObj;

    public string codigoAsignado; // Nuevo campo para el c�digo asignado

    // Este m�todo se llama al inicio para asignar un c�digo espec�fico.
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
