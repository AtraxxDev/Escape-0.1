using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderFunction : MonoBehaviour
{
    public Light pointlight;
    public Light pointlight2;
    public Light pointlight3;
    public Light pointlight4;

    private void Start()
    {
        
    }

    public void OnValueChanged(float value)
    {   
        if (pointlight != null)
        {
            pointlight.intensity = value;
        }
        if (pointlight2 != null)
        {
            pointlight2.intensity = value;
        }
        if (pointlight3 != null)
        {
            pointlight3.intensity = value;
        }
        if (pointlight4 != null)
        {
            pointlight4.intensity = value;
        }
    }
}
