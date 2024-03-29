﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager_A  : MonoBehaviour
{
    GameObject messagePanel;
    Text panelText;
    GameObject pullButton;
    GameObject[] UILayers;
    string push_text, push_not_text;

    // Start is called before the first frame update
   
    void Start()
    {
        messagePanel = GameObject.Find("PushPanel");
        panelText = GameObject.Find("PushMessage").GetComponent<Text>();
        pullButton = GameObject.Find("PullButton");
        UILayers = GameObject.FindGameObjectsWithTag("CanvasLayer");
        push_text = "Atta boy! Good job! \nNow pull it back.";
        push_not_text = "Coming in: ";
        messagePanel.SetActive(false);
        pullButton.SetActive(false);
    }

    public void SimplePush()
    {
        messagePanel.SetActive(true);
        ActivateLayerButtons(0, false);
        StartCoroutine(AnimatePush(push_text, 0.05f));
    }

    public void PushNot()
    {
        messagePanel.SetActive(true);
        ActivateLayerButtons(0, false);
        StartCoroutine(AnimateNotPush(push_not_text));
    }

    public void SimplePull()
    {
        panelText.text = "";
        pullButton.SetActive(false);
        messagePanel.SetActive(false);
        ActivateLayerButtons(0, true);
    }

    void ActivateLayerButtons(int i, bool c)
    {
        UILayers[i].GetComponentsInChildren<Button>().Select(b => b.enabled = c).ToArray();
    }

    IEnumerator AnimatePush(string text, float sec)
    {
        panelText.fontSize = 48;
        for(int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSeconds(sec);
            panelText.text += text[i];          
        }
        pullButton.SetActive(true);
    }

    IEnumerator AnimateNotPush(string text)
    {
        panelText.fontSize = 80;
        for(int i = 3;  i > 0; i--)
        {
            panelText.text = text + i;
            yield return new WaitForSeconds(1f);
        }
        SimplePull();
    }
}
