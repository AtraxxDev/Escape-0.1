using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableStorage : MonoBehaviour
{
    bool redCable = false;
    bool blueCable = false;
    bool greenCable = false;
    bool pinkCable = false;
    bool purpleCable = false;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("redCable"))
        {
            redCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("blueCable"))
        {
            blueCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("greenCable"))
        {
            greenCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("pinkCable"))
        {
            pinkCable = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("purpleCable"))
        {
            purpleCable = true;
            Destroy(collision.gameObject);
        }
    }
}
