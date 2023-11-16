using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void OnButtonClickWin()
    {
        // Llama a la función WinGame del GameManager directamente usando la instancia
        if (GameManager.instance != null)
        {
            GameManager.instance.WinGame();
        }
    }

    public void OnButtonClickStartGame()
    {
        // Llama a la función WinGame del GameManager directamente usando la instancia
        if (GameManager.instance != null)
        {
            GameManager.instance.GoToSceneAsync(0);
        }
    }
}
