using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using System;

public class Players : MonoBehaviour
{
    private Globals globals;

    private bool killable = true;

    public float knockbackX = 5;
    public float knockbackY = 0;

    [SerializeField] float yVelocityCap = 8;

    [SerializeField] Vector2 respawnOffset;

    [SerializeField] AudioSource damageClip;


    private void Awake()
    {
        globals = GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>();
        
        if (globals.spawnPos != new Vector2(0, 0))
        {
            transform.position = new Vector2(globals.spawnPos.x + respawnOffset.x, globals.spawnPos.y + respawnOffset.y);
        }
    }

    private void FixedUpdate()
    {
        // cap y-velocity
        if (GetComponent<Rigidbody2D>().velocity.y > yVelocityCap)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, yVelocityCap);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // stun and knockback when getting jumped on
        if (collision == GameObject.FindGameObjectWithTag("Player1").GetComponent<BoxCollider2D>() || collision == GameObject.FindGameObjectWithTag("Player2").GetComponent<BoxCollider2D>()) 
        {
            if (collision.gameObject == GameObject.FindGameObjectWithTag("Player1"))
            {
                GetComponent<Player2Movement>().stunned = true;
            }
            else
            {
                GetComponent<Player1Movement>().stunned = true;
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-knockbackX + (knockbackX * 2 * Convert.ToInt32(gameObject.GetComponent<SpriteRenderer>().flipX)), knockbackY), ForceMode2D.Impulse);
            damageClip.Play();
        }
    }
}