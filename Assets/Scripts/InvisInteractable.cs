using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisInteractable : MonoBehaviour
{
    [SerializeField] GameObject[] interactables;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            interactables[i].GetComponent<Interactables>().activated++;
        }
    }
}
