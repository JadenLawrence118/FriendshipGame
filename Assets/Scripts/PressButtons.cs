using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtons : MonoBehaviour
{
    [SerializeField] GameObject interactable;
    public int pressing = 0;
    private bool used = false;

    [Header("Add second button to make these buttons need to be\npushed simultaneously")] 
    [SerializeField] GameObject pairButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!used)
        {
            if (pairButton == null)
            {
                interactable.GetComponent<Interactables>().activated++;
                used = true;
            }
            else
            {
                if (pairButton.GetComponent<PressButtons>().pressing > 0)
                {
                    interactable.GetComponent<Interactables>().activated++;
                    used = true;
                }
            }
            pressing++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressing--;
    }
}
