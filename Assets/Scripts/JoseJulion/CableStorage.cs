using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private AudioSource soundTrue;
    [SerializeField] private AudioSource soundError;

    /*
    public void SetActivation(bool value)
    {
        if ((redCable = true) && (blueCable = true) && (greenCable = true) && (pinkCable = true) && (purpleCable = true))
        {
            InteractWith = value;
            OnActivated.Invoke();
        }
    }*/

    private void Update()
    {
        if (redCable == true && blueCable == true && greenCable == true && pinkCable == true && purpleCable == true)
        {
            InteractWith = true;
        }
    }

    public void CanInteract()
    {
        if(InteractWith==false)
        {
            //Aqui pondria como animación fallida y un sonido de que fallo
            soundError.Play(5);
        }
        else
        {
            soundTrue.Play(5);
            //Aqui pondria que se activa una de las cosas para abrir la caja
        }
        
    }

    public void ActivateRed()
    {
        redCable = true;
        //OtherHand.redCable = true;
        soundTrue.Play(5);
        Destroy(this.gameObject);
    }

    public void ActivateBlue()
    {
        redCable = true;
        //OtherHand.redCable = true;
        soundTrue.Play(5);
        Destroy(this.gameObject);
    }

    public void ActivateGreen()
    {
        redCable = true;
        //OtherHand.redCable = true;
        soundTrue.Play(5);
        Destroy(this.gameObject);
    }

    public void ActivatePink()
    {
        redCable = true;
        //OtherHand.redCable = true;
        soundTrue.Play(5);
        Destroy(this.gameObject);
    }

    public void ActivatePurple()
    {
        redCable = true;
        //OtherHand.redCable = true;
        soundTrue.Play(5);
        Destroy(this.gameObject);
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
