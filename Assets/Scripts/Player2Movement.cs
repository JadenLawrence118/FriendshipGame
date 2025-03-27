using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float jumpHeight = 5.0f;

    private Animator animator;
    private bool grounded = true;

    public bool stunned = false;

    [SerializeField] AudioSource footstepsAudio;

    [SerializeField] AudioSource jumpAudio;

    [SerializeField] AudioSource landAudio;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal2");

        if (horizontalInput != 0)
        {
            animator.SetBool("moving", true);

            if (grounded)
            {
                GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                GetComponent<AudioSource>().enabled = false;
            }
        }
        else
        {
            animator.SetBool("moving", false);
            GetComponent<AudioSource>().enabled = false;
        }


        // left/right

        if (horizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void FixedUpdate()
    {
        // left/right
        float horizontalInput = Input.GetAxis("Horizontal2");

        Vector2 direction = new Vector2(horizontalInput, 0);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (!stunned)
        {
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        }

        animator.SetFloat("yVelocity", rb.velocity.y);

        // jumping
        float jumpInput = Input.GetAxis("Jump2");

        if (grounded && jumpInput > 0)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumpAudio.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            landAudio.Play();
            animator.SetBool("grounded", true);
            grounded = true;
            if (stunned)
            {
                stunned = false;
                GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            animator.SetBool("grounded", false);
            grounded = false;
        }
    }
}