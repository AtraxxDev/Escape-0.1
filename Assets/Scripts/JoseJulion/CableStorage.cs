using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;

public class CableStorage : MonoBehaviour
{
   // public CableStorage OtherHand;
   // public UnityEvent OnActivated;
    private bool redCable = false;
    private bool blueCable = false;
    private bool greenCable = false;
    private bool pinkCable = false;
    private bool purpleCable = false;
    private bool InteractWith = false;

    private bool AllCables = false;

    [SerializeField] private GameObject LeverEspecial;
    [SerializeField] private AudioSource soundTrue;
    [SerializeField] private AudioSource soundError;
    [SerializeField] private AudioSource _allCableSound;
    [SerializeField] private AudioSource _takeCableSound;
    [SerializeField] private TurnOnOffLever tLever;

    [SerializeField] GameObject _redCable;
    [SerializeField] GameObject _blueCable;
    [SerializeField] GameObject _greenCable;
    [SerializeField] GameObject _pinkCable;
    [SerializeField] GameObject _purpleCable;


    private void Update()
    {
        CheckCables();
    }

    public void CheckCables()
    {
        //Si tengo todos los cables entonces el InteractWith se vuelve True
        if (redCable == true && blueCable == true && greenCable == true && pinkCable == true && purpleCable == true && !AllCables)
        {
            InteractWith = true;
            _allCableSound.Play();
            AllCables = true;
        }
    }

    public void CanInteract()
    {
        if(InteractWith==false)
        {
            //Aqui pondria como animación fallida y un sonido de que fallo
            soundError.Play();
            if (LeverEspecial != null)
            {
                Animator animator = LeverEspecial.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("Wrong");
                }
            }
        }
        else
        {
            soundTrue.Play();
            tLever.leverActivated = true;
            if (LeverEspecial != null)
            {
                Animator animator = LeverEspecial.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("Correct");
                }
            }
        }
        
    }

    public void ActivateRed()
    {
        redCable = true;
        //OtherHand.redCable = true;
        _takeCableSound.Play();
        _redCable.SetActive(false);
    }

    public void ActivateBlue()
    {
        blueCable = true;
        //OtherHand.redCable = true;
        _takeCableSound.Play();
        _blueCable.SetActive(false);
    }

    public void ActivateGreen()
    {
        greenCable = true;
        //OtherHand.redCable = true;
        _takeCableSound.Play();
        _greenCable.SetActive(false);
    }

    public void ActivatePink()
    {
        pinkCable = true;
        //OtherHand.redCable = true;
        _takeCableSound.Play();
        _pinkCable.SetActive(false);
    }

    public void ActivatePurple()
    {
        purpleCable = true;
        //OtherHand.redCable = true;
        _takeCableSound.Play();
        _purpleCable.SetActive(false);
    }


    /*
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("redCable"))
        {
            redCable = true;
            OtherHand.redCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("blueCable"))
        {
            blueCable = true;
            OtherHand.blueCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("greenCable"))
        {
            greenCable = true;
            OtherHand.greenCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("pinkCable"))
        {
            pinkCable = true;
            OtherHand.pinkCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("purpleCable"))
        {
            purpleCable = true;
            OtherHand.purpleCable = true;
            Destroy(collision.gameObject);
        }
    }*/
}
