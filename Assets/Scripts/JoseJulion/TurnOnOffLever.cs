using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffLever: MonoBehaviour
{
    public List<Light> lightList;
    private bool _light0=false;
    private bool _light1 = false;
    private bool _light2 = false;
    private bool _light3 = false;
    private bool _activate1 = true;
    private bool _activate2 = true;
    private bool _activate3 = true;
    private bool _activate4 = true;
    public bool leverActivated = false;
    public bool ispuzzleResult = false;
    [SerializeField] private GameObject _lever1;
    [SerializeField] private GameObject _lever2;
    [SerializeField] private GameObject _lever3;
    [SerializeField] private GameObject _lever4;
    [SerializeField] private GameObject _cajaShida;
    [SerializeField] private GameObject _objLight;
    [SerializeField] private AudioSource _turnLever;
    [SerializeField] private AudioSource _failedLever;
    [SerializeField] private AudioSource _soundTrue;
    [SerializeField] private AudioSource _soundCompleteLevel;
    [SerializeField] private BoxCollider KeyCollider;

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

    /*public void FixedUpdate()
    {
        ActivateBox();
    }*/

    //Si tiene todas las luces activada se abre la caja
    private void Update()
    {
        ActivateBox();
    }

    public void ActivateBox()
    {

        if (_light0 == true && _light1 == true && _light2 == true && _light3 == true && !ispuzzleResult)
        {
            lightList[4].enabled = true;
            _soundTrue.Play();
                _soundCompleteLevel.Play();
            KeyCollider.enabled = true;

            if (_cajaShida != null)
                {
                    Animator animator = _cajaShida.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetTrigger("Open"); // "Abierto" es el nombre del trigger en el Animator

                    }
                }
                if (_objLight != null)
                {
                    DoorLightController doorlight = _objLight.GetComponent<DoorLightController>();
                    if (doorlight != null)
                    {
                        doorlight.UnlockedDoor();
                    }
                }
            ispuzzleResult = true;
            Debug.Log("Complete el puzzle");
        }





    }

    public void Activation1()
    {
        if(leverActivated==true)
        {
            if (_activate1 == true)
            {
                //Cambia el Estado de la palanca
                _activate1 = false;
                //Activa la luz y el booleano de la luz correspondiente
                lightList[1].enabled = true;
                _light1 = true;
                lightList[3].enabled = false;
                _light3 = false;
                if (_lever1 != null)
                {
                    Animator animator = _lever1.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play();
            }
            else
            {
                _activate1 = true;
                lightList[1].enabled = false;
                _light1 = false;
                lightList[3].enabled = true;
                _light3 = true;
                if (_lever1 != null)
                {
                    Animator animator = _lever1.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play();
            }
        }
        else
        {
            Animator animator = _lever1.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("NuuhUhhh"); // "Abierto" es el nombre del trigger en el Animator
            }
            _failedLever.Play();
        }
    }

    public void Activation2()
    {
        if(leverActivated==true)
        {
            if (_activate2 == true)
            {
                _activate2 = false;
                lightList[2].enabled = true;
                _light2 = true;
                lightList[1].enabled = false;
                _light1= false;
                if (_lever2 != null)
                {
                    Animator animator = _lever2.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play(5);
            }
            else
            {
                _activate2 = true;
                lightList[2].enabled = false;
                _light2 = false;
                lightList[1].enabled = true;
                _light1 = true;
                if (_lever2 != null)
                {
                    Animator animator = _lever2.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play();
            }
        }
        else
        {
            Animator animator = _lever2.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("NuuhUhhh"); // "Abierto" es el nombre del trigger en el Animator
            }
            _failedLever.Play();
        }
        
    }

    public void Activation3()
    {
        if(leverActivated == true)
        {
            if (_activate3 == true)
            {
                _activate3 = false;
                lightList[3].enabled = true;
                _light3 = true;
                lightList[2].enabled = false;
                _light2 = false;
                if (_lever3 != null)
                {
                    Animator animator = _lever3.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play();
            }
            else
            {
                _activate3 = true;
                lightList[3].enabled = false;
                _light3 = false;
                lightList[2].enabled = true;
                _light2 = true;
                if (_lever3 != null)
                {
                    Animator animator = _lever3.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play();
            }
        }
        else
        {
            Animator animator = _lever3.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("NuuhUhhh"); // "Abierto" es el nombre del trigger en el Animator
            }
            _failedLever.Play();
        }
    }

    public void Activation4()
    {
        if(leverActivated==true)
        {
            if (_activate4 == true)
            {
                _activate4 = false;
                lightList[0].enabled = true;
                _light0 = true;
                lightList[2].enabled = false;
                _light2 = false;
                if (_lever4 != null)
                {
                    Animator animator = _lever4.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", true); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play();
            }
            else
            {
                _activate4 = true;
                lightList[0].enabled = false;
                _light0 = false;
                lightList[2].enabled = true;
                _light2 = true;
                if (_lever4 != null)
                {
                    Animator animator = _lever4.GetComponent<Animator>();
                    if (animator != null)
                    {
                        animator.SetBool("Activada", false); // "Abierto" es el nombre del trigger en el Animator
                    }
                }
                _turnLever.Play();
            }
        }
        else
        {
            Animator animator = _lever4.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("NuuhUhhh"); // "Abierto" es el nombre del trigger en el Animator
            }
            _failedLever.Play();
        }
    }
}
