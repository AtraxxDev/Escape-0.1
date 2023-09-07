using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumPadController : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    public RandomCodes randomCodesScript;

    // Este método se llama cuando se presiona un botón del numpad.
    public void OnNumPadButtonPress(string number)
    {
        displayText.text += number;

        if (displayText.text.Length == 4)
        {
            char[] charArray = displayText.text.ToCharArray();
            char[] codigoCorrecto = randomCodesScript.codigoAsignado.ToCharArray(); // Usamos el código asignado

            bool esCorrecto = true;

            for (int i = 0; i < 4; i++)
            {
                if (charArray[i] != codigoCorrecto[i])
                {
                    esCorrecto = false;
                    break;
                }
            }

            if (esCorrecto)
            {
                Debug.Log("Abierto");
            }
            else
            {
                Debug.Log("Failed");
                displayText.text = "";
            }
        }
    }

    
    public void OnClearButtonPress()
    {
        
        displayText.text = "";
    }
}
