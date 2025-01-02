using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtons : MonoBehaviour
{
    [SerializeField] GameObject[] interactables;
    public int pressing = 0;
    public bool used = false;

    [Header("Add second button to make these buttons need to be\npushed simultaneously")] 
    [SerializeField] GameObject pairButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            pressing++;
            if (pressing <= 1 && !used)
            {
                for (int i = 0; i < interactables.Length; i++)
                {
                    interactables[i].GetComponent<Interactables>().activated++;
                }

                if (pairButton == null)
                {
                    used = true;
                }
                else
                {
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
                for (int i = 0; i < interactables.Length; i++)
                {
                    interactables[i].GetComponent<Interactables>().activated--;
                }
            }
        }
    }
}
