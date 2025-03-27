using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public bool p1In = false;
    public bool p2In = false;

    [SerializeField] private GameObject turnBlockOn;
    [SerializeField] private GameObject turnBlockOff;

    [SerializeField] CinemachineVirtualCamera TransitionFrom;
    [SerializeField] CinemachineVirtualCamera TransitionTo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            p1In = true;
            if (p2In) 
            {
                TransitionFrom.Priority = 0;
                TransitionTo.Priority = 1;
                if (turnBlockOff != null)
                {
                    turnBlockOn.GetComponent<Collider2D>().enabled = true;
                    turnBlockOff.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
        else if (collision.tag == "Player2")
        {
            p2In = true;
            if (p1In)
            {
                TransitionFrom.Priority = 0;
                TransitionTo.Priority = 1;
                if (turnBlockOff != null)
                {
                    turnBlockOn.GetComponent<Collider2D>().enabled = true;
                    turnBlockOff.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            p1In = false;
        }
        if (collision.tag == "Player2")
        {
            p2In = false;
        }
    }
}
