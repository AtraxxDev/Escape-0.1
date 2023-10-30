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
        //codigoAsignado = codigo;
        //Text.text = ;
    }
    void Start()
    {

        codigoAsignado += 5 + "";
        codigoAsignado += 1 + "";
        codigoAsignado += 8 + "";

    }

    public void Activate()
    {
        CaptainLogObj.SetActive(true);
    }

    public void Deactivate()
    {
        CaptainLogObj.SetActive(!true);
    }
}
