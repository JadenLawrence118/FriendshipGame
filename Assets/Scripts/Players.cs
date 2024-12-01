using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;

public class Players : MonoBehaviour
{
    private Vector2 respawnPoint;

    private bool killable = true;

    private void Awake()
    {
        respawnPoint = transform.position;
    }

    public void SetRespawn(Vector2 location)
    {
        respawnPoint = location;
    }

    public void Die()
    {
        if (killable)
        {
            transform.position = respawnPoint;
            killable = false;
        }
    }
}