using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffLever: MonoBehaviour
{
    public List<Light> lightList;
    public void Activation()
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
    }
}
