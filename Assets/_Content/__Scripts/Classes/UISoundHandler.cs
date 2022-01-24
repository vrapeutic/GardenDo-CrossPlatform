using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundHandler : MonoBehaviour
{
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip clickSound;

  [SerializeField]  AudioSource myAudioSource;
    private void Start()
    {
        if (!Statistics.android)
        {
            if(!myAudioSource) myAudioSource = this.GetComponent<AudioSource>();
        } 
    }
    public void PlayHoverSound()
    {
        myAudioSource.clip = hoverSound;
        myAudioSource.Play();
        Debug.Log("hover sound played");
    }
    public void PlayClickSound()
    {
        myAudioSource.clip = clickSound;
        myAudioSource.Play();
        Debug.Log("click sound played");
    }
}
