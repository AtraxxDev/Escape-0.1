using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumPadFijo : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;

    public ShowPW randomCodesScript;
    public GameObject object_Animator;
    public GameObject object_Light;
    public GameObject object_Light2;
    public AudioSource soundError;
    public AudioSource soundTrue;
    public GameObject CanvasUI1;
    [SerializeField] private BoxCollider KeyCollider;



    // Este m�todo se llama cuando se presiona un bot�n del numpad.
    public void OnNumPadButtonPress(string number)
    {
        displayText.text += number;


        if (displayText.text.Length == 3)
        {
            char[] charArray = displayText.text.ToCharArray();

            char[] codigoCorrecto = randomCodesScript.codigoAsignado.ToCharArray(); // Usamos el c�digo asignado

            bool esCorrecto = true;

            for (int i = 0; i < 3; i++)
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

                if (object_Animator != null)
                {
                    Animator animator = object_Animator.GetComponent<Animator>();
                    if (animator != null)
                    {
                        Debug.Log("Estoy abierto");
                        animator.SetTrigger("Open"); // "Abierto" es el nombre del trigger en el Animator
                        CanvasUI1.SetActive(false);
                    }
                }

                if (object_Light != null)
                {
                    DoorLightController doorlight = object_Light.GetComponent<DoorLightController>();

                    if (doorlight != null)
                    {
                        doorlight.UnlockedDoor();
                    }
                }

                if (object_Light2 != null)
                {
                    DoorLightController doorlight2 = object_Light2.GetComponent<DoorLightController>();

                    if (doorlight2 != null)
                    {
                        doorlight2.UnlockedDoor();
                    }
                }

                KeyCollider.enabled = true;
                soundTrue.Play(5);




            }
            else
            {
                Debug.Log("Failed");
                displayText.text = "";
                soundError.Play(5);
            }
        }
    }


    public void OnClearButtonPress()
    {

        displayText.text = "";
    }
}
