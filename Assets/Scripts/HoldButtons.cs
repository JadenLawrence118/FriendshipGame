using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtons : MonoBehaviour
{
    [SerializeField] GameObject[] interactables;

    public int pressing = 0;

    [Header("The sprite that will be used when the button is being pressed")]
    public Sprite downSprite;
    private Sprite upSprite;

    private void Awake()
    {
        upSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = downSprite;
        GetComponent<AudioSource>().Play();
        if (!collision.isTrigger)
        {
            pressing++;

            if (pressing > 0)
            {
                for (int i = 0; i < interactables.Length; i++)
                {
                    interactables[i].GetComponent<Interactables>().activated++;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            pressing--;
            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].GetComponent<Interactables>().activated--;
            }

            if (pressing <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = upSprite;
            }
        }
    }
}
