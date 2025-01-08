using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtons : MonoBehaviour
{
    [SerializeField] GameObject[] interactables;
    public int pressing = 0;
    public bool used = false;

    [Header("The sprite that will be used when the button is being pressed")]
    public Sprite downSprite;
    private Sprite upSprite;

    [Header("Add second button to make these buttons need to be\npushed simultaneously")] 
    [SerializeField] GameObject pairButton;


    private void Awake()
    {
        upSprite = GetComponent<SpriteRenderer>().sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            pressing++;
            if (pressing <= 1 && !used)
            {
                GetComponent<SpriteRenderer>().sprite = downSprite;

                // increments the interactable's activated variable
                for (int i = 0; i < interactables.Length; i++)
                {
                    interactables[i].GetComponent<Interactables>().activated++;
                }

                // prevents the interactable's activated variable from being decremented when the player stops holding the button if there is no pair button
                if (pairButton == null)
                {
                    used = true;
                }
                else
                {
                    // prevents the interactable's activated variable from being decremented when the player stops holding the button if the pair button is also held
                    if (pairButton.GetComponent<PressButtons>().pressing > 0)
                    {
                        used = true;
                        pairButton.GetComponent<PressButtons>().used = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            pressing--;
            if (pressing <= 0 && !used)
            {
                GetComponent<SpriteRenderer>().sprite = upSprite;

                for (int i = 0; i < interactables.Length; i++)
                {
                    interactables[i].GetComponent<Interactables>().activated--;
                }
            }
        }
    }
}
