using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [Header("For each respawnTarget, set its spawner in the correct array position\nin targetSpawner")]

    [SerializeField] GameObject[] respawnTarget;
    [SerializeField] GameObject[] targetSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < respawnTarget.Length; i++)
        {
            if (respawnTarget[i].GetComponent<Collider2D>() == collision)
            {
                respawnTarget[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                respawnTarget[i].transform.rotation = new Quaternion(0, 0, 0, 0);
                respawnTarget[i].transform.position = targetSpawner[i].transform.position;
            }
        }
    }
}
