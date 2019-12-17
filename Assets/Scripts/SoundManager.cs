using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;
    }

    public AudioSource GetSound()
    {
        return audioSource;
    }

    public AudioClip SetSound(int index)
    {
        if (audioClips[index]) return audioClips[index];
        return null;
    }

    public void PlaySound(int index)
    {
        if (audioClips[index]) audioSource.clip = audioClips[index];
        else return;
        audioSource.Play();
    }
}
