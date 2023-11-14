using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool Key1;
    public bool Key2;
    public bool Key3;
    public bool Key4;

    public void ClearKeys()
    {
        Key1 = false; Key2 = false; Key3 = false; Key4 = false;
    }

}
