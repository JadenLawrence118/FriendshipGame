using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioSource StartClip;
    [SerializeField] AudioSource LoopClip;

    private bool looping = false;

    void Update()
    {
        if (!looping)
        {
            if (!StartClip.isPlaying)
            {
                LoopClip.Play();
                looping = true;
            }
        }
    }
}
