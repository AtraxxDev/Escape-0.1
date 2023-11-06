using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasesChad : MonoBehaviour
{


    public float MaxFrasco1=8; //4,2,6-Meta
    public float MaxFrasco2=6; //4,6,2
    public float MaxFrasco3=4; //3,4

    public float recieverFlask=4;
    public float senderFlask=4;
    public float emptyFlask=0;


    private void Update()
    {
       
    }

    public void Fill(int Flasktype,float amount)
    {
        switch(Flasktype)
        {
            case 1:
                recieverFlask= Mathf.Clamp(recieverFlask+amount,0,MaxFrasco1); 
                break;
            case 2:
                senderFlask = Mathf.Clamp(recieverFlask + amount, 0, MaxFrasco1);
                break;
            case 3:
                emptyFlask = Mathf.Clamp(recieverFlask + amount, 0, MaxFrasco1);
                break;
        }
    }

    public void Empty()
    {

    }
}
