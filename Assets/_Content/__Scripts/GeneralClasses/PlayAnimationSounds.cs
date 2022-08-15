using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationSounds : MonoBehaviour
{
    public AudioSource audioSource;
    private void Start()
    {
        if (!audioSource) audioSource = this.GetComponent<AudioSource>();
    }
    public void PlayAudio(AudioClip audio)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audio);
    }
}