using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static bool play1;
    public static bool play2;

    public AudioClip a1;
    public AudioClip a2;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (play1)
        {
            audioSource.PlayOneShot(a1, .7f);
            play1 = false;
        }
        if (play2)
        {
            audioSource.PlayOneShot(a2, .7f);
            play2 = false;
        }
    }
}
