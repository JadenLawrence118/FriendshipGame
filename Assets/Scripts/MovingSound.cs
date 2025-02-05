using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingSound : MonoBehaviour
{
    private float previousXPosition;
    void FixedUpdate()
    {
        if (transform.localPosition.x != previousXPosition)
        {
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }
        previousXPosition = transform.localPosition.x;
    }
}
