using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoors : MonoBehaviour
{
    private bool moving = false;

    [SerializeField] float closeSpeed = 5.0f;

    private float targetPos;

    private float startPos;

    private bool closedDown = true;

    private bool canMove = true;

    [SerializeField] private GameObject[] stopCollisions;

    private void Awake()
    {
        startPos = transform.position.y;
        targetPos = transform.parent.transform.GetChild(transform.GetSiblingIndex() + 1).position.y; // gets next child in its parent
        if (targetPos >= transform.position.y)
        {
            closedDown = true;
        }
        else
        {
            closedDown = false;
        }
    }
    private void Update()
    {
        if (moving)
        {
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (canMove) 
        {
            if (gameObject.GetComponent<Interactables>().activated >= gameObject.GetComponent<Interactables>().activeNeeded)
            {
                if (closedDown)
                {
                    if (transform.position.y < targetPos)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y + closeSpeed * Time.deltaTime);
                        moving = true;
                    }
                    else
                    {
                        moving = false;
                    }
                }
                else
                {
                    if (transform.position.y > targetPos)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y - closeSpeed * Time.deltaTime);
                        moving = true;
                    }
                    else
                    {
                        moving = false;
                    }
                }
            }
            else
            {
                if (closedDown)
                {
                    if (transform.position.y > startPos)
                    {

                        transform.position = new Vector2(transform.position.x, transform.position.y - closeSpeed * Time.deltaTime);
                        moving = true;
                    }
                    else
                    {
                        moving = false;
                    }
                }
                else
                {
                    if (transform.position.y < startPos)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y + closeSpeed * Time.deltaTime);
                        moving = true;
                    }
                    else
                    {
                        moving = false;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < stopCollisions.Length; i++)
        {
            if (collision.gameObject == stopCollisions[i])
            {
                canMove = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < stopCollisions.Length; i++)
        {
            if (collision.gameObject == stopCollisions[i])
            {
                canMove = true;
            }
        }
    }
}
