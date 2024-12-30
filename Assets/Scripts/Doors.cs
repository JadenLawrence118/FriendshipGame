using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool startClosed = false;

    private void Awake()
    {
        if (gameObject.GetComponent<Collider2D>().enabled)
        {
            startClosed = true;
        }
    }
    private void Update()
    {
        if (gameObject.GetComponent<Interactables>().activated >= gameObject.GetComponent<Interactables>().activeNeeded)
        {
            gameObject.GetComponent<Collider2D>().enabled = !startClosed;
            gameObject.GetComponent<SpriteRenderer>().enabled = !startClosed;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = startClosed;
            gameObject.GetComponent<SpriteRenderer>().enabled = startClosed;
        }
    }
}
