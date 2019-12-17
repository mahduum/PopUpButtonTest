using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager_A  : MonoBehaviour
{
    GameObject messagePanel;
    Text panelText;
    GameObject pullButton;
    string push_text, push_not_text;
    //AudioSource audioSource;

    // Start is called before the first frame update
   
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        messagePanel = GameObject.Find("PushPanel");
        panelText = GameObject.Find("PushMessage").GetComponent<Text>();
        pullButton = GameObject.Find("PullButton");
        push_text = "Atta boy! Good job! \nNow pull it back.";
        push_not_text = "Coming in: ";
        messagePanel.SetActive(false);
        pullButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (simpleText && simpleTextOn) StartCoroutine(AnimateText(push_text));
    }

    public void SimplePush()
    {
        messagePanel.SetActive(true);
     
        StartCoroutine(AnimatePush(push_text, 0.05f));
    }

    public void PushNot()
    {
        messagePanel.SetActive(true); 
        StartCoroutine(AnimateNotPush(push_not_text));
    }

    //public void PushHarder()
    //{
    //    audioSource.Play();
    //}

    public void SimplePull()
    {
        panelText.text = "";
        pullButton.SetActive(false);
        messagePanel.SetActive(false);
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
