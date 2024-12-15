using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFadeOut : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 0.001f;

    [Header("Add second text to make that fade in when this\nfades out")]
    [SerializeField] GameObject nextText;
    private void Update()
    {
        if (gameObject.GetComponent<Interactables>().activated > 0)
        {
            if (GetComponent<TextMeshProUGUI>().material.color.a > 0)
            {
                Color newColour = GetComponent<TextMeshProUGUI>().color;
                newColour.a -= fadeSpeed;
                GetComponent<TextMeshProUGUI>().color = newColour;
            }

            if (nextText != null && nextText.GetComponent<TextMeshProUGUI>().material.color.a < 246)
            {
                Color newColour = nextText.GetComponent<TextMeshProUGUI>().color;
                newColour.a += fadeSpeed;
                nextText.GetComponent<TextMeshProUGUI>().color = newColour;
            }
        }
    }
}
