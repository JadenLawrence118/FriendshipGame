using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtons : MonoBehaviour
{
    [SerializeField] GameObject[] interactables;

    public int pressing = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        }
    }
}
