using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightController : MonoBehaviour
{
    public bool LockDoor;
    public int _numberSceneLoad;
    public GameObject LightGreen;
    public GameObject LightRed;
    public SceneTransitionManager _sceneTransition;
   // public Animator _anim;
    public AudioSource lockSound;
    public AudioSource UnlockSound;
    public OnAndOffObject on_off;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UnlockedDoor()
    {
        LockDoor = false;
        LightGreen.SetActive(true);
        LightRed.SetActive(false);
    }

   public void CheckDoor()
    {

        if (LockDoor == true)
        {
            lockSound.Play();
        }

        if (LockDoor == false)
        {
            Debug.Log("Me voy a Prender");
            on_off.ObjectOn();
            Debug.Log("Me Prendi");
            UnlockSound.Play();
            _sceneTransition.GoToSceneAsync(_numberSceneLoad);

        }
    }

    

}
