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

    public DoorLightController otherDoor;
    // Start is called before the first frame update
    void Start()
    {
        Load();
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Load()
    {
        
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        
        string clearedKey = currentSceneName + "_cleared";

        if (PlayerPrefs.GetInt(clearedKey, 0) == 1)
        {
            UnlockedDoor();

        }
    }

    public void UnlockedDoor()
    {
        Debug.Log("Desbloquee la puerta principal");
        LockDoor = false;
        LightGreen.SetActive(true);
        LightRed.SetActive(false);



        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        string clearedKey = currentSceneName + "_cleared";

       /* if(otherDoor != null) 
        {
            Debug.Log("Desbloquee la puerta Secundaria");

            otherDoor.UnlockedDoor();
            
        }*/

        PlayerPrefs.SetInt(clearedKey, 1);
        PlayerPrefs.Save();
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
