using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.GetComponent<Interactables>().activated >= gameObject.GetComponent<Interactables>().activeNeeded)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
