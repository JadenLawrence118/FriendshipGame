using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtons : MonoBehaviour
{
    [SerializeField] GameObject[] interactables;
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
                for (int i = 0; i < interactables.Length; i++)
                {
                    interactables[i].GetComponent<Interactables>().activated++;
                    used = true;
                }
            }
            else
            {
                for (int i = 0; i < interactables.Length; i++)
                {
                    if (pairButton.GetComponent<PressButtons>().pressing > 0)
                    {
                        interactables[i].GetComponent<Interactables>().activated++;
                        used = true;
                    }
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
