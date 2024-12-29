using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1.0f;

    [Header("Add second text to make that fade in when this\nfades out")]
    [SerializeField] GameObject nextText;

    private bool doneFadeIn = false;
    private void Update()
    {
        if (gameObject.GetComponent<Interactables>().activated >= gameObject.GetComponent<Interactables>().activeNeeded)
        {
            // fade out
            if (GetComponent<TextMeshProUGUI>().color.a > 0)
            {
                Color newColour = GetComponent<TextMeshProUGUI>().color;
                newColour.a -= fadeSpeed * Time.deltaTime;
                GetComponent<TextMeshProUGUI>().color = newColour;
            }


            // fade in next text
            if (!doneFadeIn)
            {
                if (nextText != null && nextText.GetComponent<TextMeshProUGUI>().color.a < 0.6)
                {
                    Color newColour = nextText.GetComponent<TextMeshProUGUI>().color;
                    newColour.a += fadeSpeed * Time.deltaTime;
                    nextText.GetComponent<TextMeshProUGUI>().color = newColour;
                }
                else
                {
                    doneFadeIn = true;
                }
            }
        }
    }
}
