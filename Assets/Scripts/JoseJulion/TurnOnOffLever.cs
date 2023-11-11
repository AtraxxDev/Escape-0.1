using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffLever: MonoBehaviour
{
    public List<Light> lightList;
    private bool Light1=false;
    private bool Light2=false;
    private bool Light3=false;
    private bool Light4 = false;
    private bool Activate1=true;
    private bool Activate2=true;
    private bool Activate3 = true;
    private bool Activate4 = true;
    [SerializeField] private AudioSource TurnOnLever;
    [SerializeField] private AudioSource TurnOffLever;

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

    public void Activation1()
    {
        if(Activate1==true)
        {
            Activate1 = false;
            lightList[0].enabled = true;
            Light1 = true;
            lightList[1].enabled = true;
            Light2 = true;
            TurnOnLever.Play(5);
        }
        else
        {
            Activate1 = true;
            lightList[0].enabled = false;
            Light1 = false;
            lightList[1].enabled = false;
            Light2 = false;
            TurnOffLever.Play(5);
        }
     
    }

    public void Activation2()
    {
        if(Activate2==true)
        {
            Activate2 = false;
            lightList[2].enabled = true;
            Light3 = true;
            lightList[1].enabled = false;
            Light2 = false;
            TurnOnLever.Play(5);
        }
        else
        {
            Activate2 = true;
            lightList[2].enabled = false;
            Light3 = false;
            lightList[1].enabled = true;
            Light2 = true;
            TurnOffLever.Play(5);
        }
    }

    public void Activation3()
    {
        if(Activate3==true)
        {
            Activate3 = false;
            lightList[3].enabled = true;
            Light4 = true;
            lightList[2].enabled = false;
            Light3 = false;
            TurnOnLever.Play(5);
        }
        else
        {
            Activate3 = true;
            lightList[3].enabled = false;
            Light4 = false;
            lightList[2].enabled = true;
            Light3 = true;
            TurnOffLever.Play(5);
        }
      
    }

    public void Activation4()
    {
        if(Activate4==true)
        {
            Activate4 = false;
            lightList[2].enabled = true;
            Light3 = true;
            lightList[0].enabled = false;
            Light1 = false;
            TurnOnLever.Play(5);
        }
        else
        {
            Activate4 = true;
            lightList[2].enabled = false;
            Light3 = false;
            lightList[0].enabled = true;
            Light1 = true;
            TurnOffLever.Play(5);
        }
       

    }
}
