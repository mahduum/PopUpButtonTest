using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager_B : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panelTextField;
    [SerializeField] GameObject pullButton;
    SoundManager soundManager;
    Text text;
    string push_text, push_not_text;

    void Start()
    {
        text = panelTextField.GetComponent<Text>();
        push_text = "Atta boy! Good job! \nNow pull it back.";
        push_not_text = "Coming in: ";
        panel.SetActive(false);
        pullButton.SetActive(false);
        soundManager = GetComponent<SoundManager>();
    }

    public void SimplePush()
    {
        panel.SetActive(true);
     
        StartCoroutine(AnimatePush(push_text));
    }

    public void PushNot()
    {
        panel.SetActive(true); 
        StartCoroutine(AnimateNotPush(push_not_text));
    }

    public void PushHarder()
    {
        soundManager.PlaySound(4);
    }

    public void SimplePull()
    {
        text.text = "";
        pullButton.SetActive(false);
        panel.SetActive(false);
    }

    IEnumerator AnimatePush(string _text)
    {
        this.text.fontSize = 48;
        float t = 0;
        for(int i = 0; i < _text.Length; i++)
        {
            t = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(t);
            if (_text[i].CompareTo('\n') == 0)
            {
                soundManager.PlaySound(1);
                yield return new WaitWhile(() => soundManager.GetSound().isPlaying);
            }
            else if (_text[i].CompareTo(' ') == 0)
            {
                soundManager.PlaySound(2);
                yield return new WaitWhile(() => soundManager.GetSound().isPlaying);
            }
            else
            {
                soundManager.PlaySound(0);
            }
            this.text.text += _text[i];          
        }
        pullButton.SetActive(true);
    }

    IEnumerator AnimateNotPush(string _text)
    {
        this.text.fontSize = 80;
        for(int i = 3;  i > 0; i--)
        {
            this.text.text = _text + i;
            soundManager.PlaySound(3);
            yield return new WaitForSeconds(1f);
        }
        SimplePull();
    }
}
