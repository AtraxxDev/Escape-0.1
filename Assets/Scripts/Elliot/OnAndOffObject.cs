using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOffObject : MonoBehaviour
{
    public GameObject _object;
    
    public void ObjectOn() 
    {
        _object.SetActive(true);
    }

    public void ObjectOff()
    {
        _object.SetActive(false);
    }
}
