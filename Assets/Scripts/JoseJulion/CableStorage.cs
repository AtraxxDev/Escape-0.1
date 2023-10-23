using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CableStorage : MonoBehaviour
{
    public CableStorage OtherHand;
    public UnityEvent OnActivated;
    public bool redCable = false;
    public bool blueCable = false;
    public bool greenCable = false;
    public bool pinkCable = false;
    public bool purpleCable = false;
    public bool InteractWith = false;

    public void SetActivation(bool value)
    {
        if ((redCable = true) && (blueCable = true) && (greenCable = true) && (pinkCable = true) && (purpleCable = true))
        {
            InteractWith = value;
            OnActivated.Invoke();
        }
    }

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
    }
}
