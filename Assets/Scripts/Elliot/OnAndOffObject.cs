using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOffObject : MonoBehaviour
{
    public GameObject _object;

    public void ObjectOn()
    {
        if (_object != null)
        {
            _object.SetActive(true);
        }
        else
        {
            Debug.LogWarning("El objeto de referencia es nulo en ObjectOn().");
        }
    }

    public void ObjectOff()
    {
        if (_object != null)
        {
            _object.SetActive(false);
        }
        else
        {
            Debug.LogWarning("El objeto de referencia es nulo en ObjectOff().");
        }
    }
}
