using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffLever: MonoBehaviour
{
    public List<Light> lightList;
    private bool Light1=false;
    private bool Light2=false;
    private bool Light3=false;
    private bool Light4 = false;
    private bool Activate1=true;
    private bool Activate2=true;
    private bool Activate3 = true;
    private bool Activate4 = true;
    public bool LeverActivated = false;
    [SerializeField] private GameObject Lever1;
    [SerializeField] private GameObject Lever2;
    [SerializeField] private GameObject Lever3;
    [SerializeField] private GameObject Lever4;
    [SerializeField] private GameObject CajaShida;
    [SerializeField] private AudioSource TurnOnLever;
    [SerializeField] private AudioSource TurnOffLever;

    /* public void Activation()
     {
         //RECORRE LA LISTA
         for(int i = 0; i < lightList.Count; i++) 
         {
             //CHECA SI EXISTE
             if (lightList[i] != null) 
             {
                 //FLIP
                 if (lightList[i].enabled)
                 {
                     lightList[i].enabled = false;
                 }
                 else
                 {
                     lightList[i].enabled = true;
                 }
             }
         }
     }*/

    public void FixedUpdate()
    {
        ActivateBox();
    }

    //Si tiene todas las luces activada se abre la caja
    public void ActivateBox()
    {
        if (Light1 == true && Light2 == true && Light3 == true && Light4 == true)
        {
            if (CajaShida != null)
            {
                Animator animator = CajaShida.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("Open"); // "Abierto" es el nombre del trigger en el Animator
                                                 // CanvasUI1.SetActive(false);
                }
            }
        }
        
    }

    public void Activation1()
    {
        if(LeverActivated==true)
        {
            if (Activate1 == true)
            {
                //Cambia el Estado de la palanca
                Activate1 = false;
                //Activa la luz y el booleano de la luz correspondiente
                lightList[0].enabled = true;
                Light1 = true;
                lightList[1].enabled = true;
                Light2 = true;
                if (Lever1 != null)
                {
                    Animator animator = Lever1.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                TurnOnLever.Play(5);
            }
            else
            {
                Activate1 = true;
                lightList[0].enabled = false;
                Light1 = false;
                lightList[1].enabled = false;
                Light2 = false;
                if (Lever1 != null)
                {
                    Animator animator = Lever1.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                TurnOffLever.Play(5);
            }
        }             
    }

    public void Activation2()
    {
        if(LeverActivated==true)
        {
            if (Activate2 == true)
            {
                Activate2 = false;
                lightList[2].enabled = true;
                Light3 = true;
                lightList[1].enabled = false;
                Light2 = false;
                if (Lever2 != null)
                {
                    Animator animator = Lever2.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                TurnOnLever.Play(5);
            }
            else
            {
                Activate2 = true;
                lightList[2].enabled = false;
                Light3 = false;
                lightList[1].enabled = true;
                Light2 = true;
                if (Lever2 != null)
                {
                    Animator animator = Lever2.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                TurnOffLever.Play(5);
            }
        }
        
    }

    public void Activation3()
    {
        if(LeverActivated == true)
        {
            if (Activate3 == true)
            {
                Activate3 = false;
                lightList[3].enabled = true;
                Light4 = true;
                lightList[2].enabled = false;
                Light3 = false;
                if (Lever3 != null)
                {
                    Animator animator = Lever3.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                TurnOnLever.Play(5);
            }
            else
            {
                Activate3 = true;
                lightList[3].enabled = false;
                Light4 = false;
                lightList[2].enabled = true;
                Light3 = true;
                if (Lever3 != null)
                {
                    Animator animator = Lever3.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                TurnOffLever.Play(5);
            }
        }              
    }

    public void Activation4()
    {
        if(Activate4==true)
        {
            Activate4 = false;
            lightList[2].enabled = true;
            Light3 = true;
            lightList[0].enabled = false;
            Light1 = false;
            if (Lever4 != null)
            {
                Animator animator = Lever4.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                }
            }
            TurnOnLever.Play(5);
        }
        else
        {
            Activate4 = true;
            lightList[2].enabled = false;
            Light3 = false;
            lightList[0].enabled = true;
            Light1 = true;
            if (Lever4 != null)
            {
                Animator animator = Lever4.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                }
            }
            TurnOffLever.Play(5);
        }
       

    }
}
