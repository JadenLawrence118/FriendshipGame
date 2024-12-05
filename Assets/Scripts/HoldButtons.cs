using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtons : MonoBehaviour
{
    [SerializeField] GameObject interactable;

    public int pressing = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pressing++;

        if (pressing > 0)
        {
            interactable.GetComponent<Interactables>().activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressing--;

        if (pressing <= 0)
        {
            interactable.GetComponent<Interactables>().activated = false;
        }
    }
}
