using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPW : MonoBehaviour
{
    //[SerializeField] private TMP_Text Text;
    public GameObject CaptainLogObj;

    public string codigoAsignado; // Nuevo campo para el c�digo asignado
    public int codigo1=5;
    public int codigo2=1;
    public int codigo3=8;

    // Este m�todo se llama al inicio para asignar un c�digo espec�fico.
    public void AsignarCodigo(string codigo)
    {
        //codigoAsignado = codigo;
        //Text.text = ;
    }
    void Start()
    {

        codigoAsignado += codigo1 + "";
        codigoAsignado += codigo2 + "";
        codigoAsignado += codigo3 + "";

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
