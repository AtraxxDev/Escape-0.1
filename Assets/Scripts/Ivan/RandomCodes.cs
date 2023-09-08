using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomCodes : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    
    public string codigoAsignado; // Nuevo campo para el c�digo asignado

    // Este m�todo se llama al inicio para asignar un c�digo espec�fico.
    public void AsignarCodigo(string codigo)
    {
        codigoAsignado = codigo;
        Text.text = codigoAsignado;
    }

    // Start is called before the first frame update
    void Start()
    {

        codigoAsignado += Random.Range(1, 9) + "";
        codigoAsignado += Random.Range(1, 9) + "";
        codigoAsignado += Random.Range(1, 9) + "";
        codigoAsignado += Random.Range(1, 9) + "";

        

        Text.text = "" + codigoAsignado;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
