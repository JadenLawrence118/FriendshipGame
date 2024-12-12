using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFadeOut : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 0.001f;
    private void Update()
    {
        if (gameObject.GetComponent<Interactables>().activated > 0)
        {
            if (GetComponent<TextMeshProUGUI>().material.color.a < 246)
            {
                Color newColour = GetComponent<TextMeshProUGUI>().color;
                newColour.a -= 0.001f;
                GetComponent<TextMeshProUGUI>().color = newColour;
            }
        }
    }
}
