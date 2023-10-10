using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    GameObject[] buttons;
    GameObject[] lightArray;
    GameObject[] rowLights;
    int[] lightOrder;
    GameObject displayPanel;
    int level = 0;
    int buttonsCliked = 0;
    int colorOrderRunCount = 0; 
    bool passed = false;
    bool won = false;
    Color red = new Color(255, 39, 0, 255);
    Color green = new Color(4, 204, 0, 255);
    Color invisible = new Color(4, 204, 0, 0);
    Color white = new Color(255, 255, 255, 255);
    public float lightspeed;

    private void OnEnable()
    {
        level = 0;
        buttonsCliked = 0;
        colorOrderRunCount = -1;
        won = false;
        for(int i = 0; i < lightOrder.Length; i++)
        {
            lightOrder[i] = Random.Range(0, 3);
        }
        for(int i = 0;i < rowLights.Length; i++)
        {
            rowLights[i].GetComponent<Image>().color = white;
        }
        level = 1;

        StartCoroutine(ColorOrder());
    }

    public void ButtonClickOrder(int button)
    {
        buttonsCliked++;
        if (button == lightOrder[buttonsCliked - 1])
        {
            passed = true;
        }
        else 
        {
            won = false;
            passed = false;
            StartCoroutine(ColorBlink(red));
        }
        if (buttonsCliked == level && passed == true && buttonsCliked != 4)
        {
            level++;
            passed = false;
            StartCoroutine (ColorOrder());
        }
        if (buttonsCliked == level && passed == true && buttonsCliked == 4)
        {
            StartCoroutine (ColorBlink(green));
        }
    }

    public void closePanel()
    {
        displayPanel.SetActive(false);
    }
    public void openPanel()
    {
        displayPanel.SetActive(true);
    }

    IEnumerator ColorBlink(Color colorToBlink)
    {
        disableInteractableButtons();
        for (int i = 0; i < 3; i ++)
        {
            buttons[i].GetComponent<Image>().color = colorToBlink;
        }
        for (int i = 4; i < rowLights.Length; i++)
        {
            rowLights[i].GetComponent<Image>().color = colorToBlink;
        }
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().color = white;
        }
        for (int i = 4; i < rowLights.Length; i++)
        {
            buttons[i].GetComponent<Image>().color = white;
        }
        enableInteractableButtons();
        OnEnable();
    }

    IEnumerator ColorOrder() 
    {
        buttonsCliked = 0;
        colorOrderRunCount = 0;
        disableInteractableButtons();
        for (int i = 0; i < colorOrderRunCount; i ++)
        {
            if(level >= colorOrderRunCount)
            {
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                yield return new WaitForSeconds(lightspeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = green;
                yield return new WaitForSeconds(lightspeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                rowLights[i].GetComponent <Image>().color = green;
            }
            enableInteractableButtons();
        }
    }

    void disableInteractableButtons()
    {
        for (int i = 0;i < buttons.Length;i ++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    void enableInteractableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }
}
