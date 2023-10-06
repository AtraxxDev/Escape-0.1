using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightController : MonoBehaviour
{
    public bool LockDoor;
    public float timeChangeFade = 2;
    public GameObject LightGreen;
    public GameObject LightRed;
   // public Animator _anim;
    public AudioSource lockSound;
    public AudioSource UnlockSound;
    // Start is called before the first frame update
    void Start()
    {
        LockDoor = true;
       
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
            UnlockSound.Play();
           // _anim.SetTrigger("FadeIn"); // "FadeIn" es el nombre del trigger en el Animator
           // StartCoroutine(playFadeAnim());           
        }
    }

    
    IEnumerator playFadeAnim() 
    {
        UnlockSound.Play();
       // _anim.SetTrigger("FadeIn"); // "FadeIn" es el nombre del trigger en el Animator
        yield return new WaitForSeconds (timeChangeFade);
      //  _anim.SetTrigger("FadeOut"); // "FadeOut" es el nombre del trigger en el Animator
    }
}
