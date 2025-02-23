using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBehaviour : MonoBehaviour
{
    private Animator animator;

    private bool grounded = true;

    float lastXPos;

    private bool shouldMove = true;

    [SerializeField] private float jumpHeight = 5.0f;

    [SerializeField] AudioSource footstepsAudio;

    [SerializeField] AudioSource jumpAudio;

    [SerializeField] AudioSource landAudio;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int horizontalMovement;

        if (lastXPos < transform.position.x)
        {
            horizontalMovement = 1;
        }
        else if (lastXPos > transform.position.x)
        {
            horizontalMovement = -1;

        }
        else
        {
            horizontalMovement = 0;
        }

        // animations
        if (shouldMove && horizontalMovement != 0)
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
        if (horizontalMovement < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalMovement > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        lastXPos = transform.position.x;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("yVelocity", -1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            landAudio.Play();
            animator.SetBool("grounded", true);
            grounded = true;
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

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        jumpAudio.Play();
    }

    public void SetShouldMove(bool move)
    {
        shouldMove = move;
    }
}
