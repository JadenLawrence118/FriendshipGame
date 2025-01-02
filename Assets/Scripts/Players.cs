using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;

public class Players : MonoBehaviour
{
    private Globals globals;

    private bool killable = true;

    private void Awake()
    {
        globals = GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>();
        
        if (globals.spawnPos != new Vector2(0, 0))
        {
            transform.position = globals.spawnPos;
        }
    }

    public void SetRespawn(Vector2 location)
    {
        globals.spawnPos = location;
    }

    public void Die()
    {
        if (killable)
        {
            transform.position = globals.spawnPos;
            killable = false;
        }
    }
}