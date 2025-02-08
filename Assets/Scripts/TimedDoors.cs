using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoors : MonoBehaviour
{
    private bool moving = false;

    [SerializeField] float closeSpeed = 5.0f;

    public float targetPos;

    public float startPos;

    private bool closedDown = true;

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
