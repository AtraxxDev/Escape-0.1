using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOffObject : MonoBehaviour
{
    public GameObject OnObject;


    public void ObjectOn()
    {
        OnObject.SetActive(true);
    }

    public void ObjectOff()
    {
        OnObject.SetActive(false);

    }
}
