using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlanes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            GameObject.FindGameObjectWithTag("Player1").GetComponent<Players>().Die();
        }
        else if (collision.tag == "Player2")
        {
            GameObject.FindGameObjectWithTag("Player2").GetComponent<Players>().Die();
        }
    }
}
