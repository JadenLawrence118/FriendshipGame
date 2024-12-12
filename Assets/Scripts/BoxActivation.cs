using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActivation : MonoBehaviour
{
    [SerializeField] private GameObject activationCollider;
    [SerializeField] GameObject[] interactables;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == activationCollider.GetComponent<Collider2D>())
        {
            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].GetComponent<Interactables>().activated++;
            }
        }
    }
}
