using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player1Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float jumpHeight = 5.0f;

    private Animator animator;
    private bool grounded = true;

    private Globals globals;

    private GameObject pauseMenu;

    public bool stunned = false;

    [SerializeField] AudioSource footstepsAudio;

    [SerializeField] AudioSource jumpAudio;

    [SerializeField] AudioSource landAudio;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        globals = GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>();

        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        pauseMenu.SetActive(false);
        globals.paused = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal1");

        // animations
        if (horizontalInput != 0)
        {
            animator.SetBool("moving", true);
            
            if (grounded)
            {
                footstepsAudio.enabled = true;
            }
            else
            {
                footstepsAudio.enabled = false;
            }
        }
        else
        {
            animator.SetBool("moving", false);
            footstepsAudio.enabled = false;
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

        // pausing
        if (Input.GetKeyUp("escape"))
        {
            if (globals.paused)
            {
                Time.timeScale = 1.0f;
                globals.paused = false;
                globals.resumeClip.Play();
                pauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                globals.paused = true;
                globals.pauseClip.Play();
                pauseMenu.SetActive(true);
            }
        }
    }
    private void FixedUpdate()
    {
        // left/right
        float horizontalInput = Input.GetAxis("Horizontal1");

        Vector2 direction = new Vector2(horizontalInput, 0);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (!stunned)
        {
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        }

        animator.SetFloat("yVelocity", rb.velocity.y);

        // jumping
        float jumpInput = Input.GetAxis("Jump1");

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