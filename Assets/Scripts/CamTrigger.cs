using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    private bool p1In = false;
    private bool p2In = false;

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
            }
        }
        else if (collision.tag == "Player2")
        {
            p2In = true;
            if (p1In)
            {
                TransitionFrom.Priority = 0;
                TransitionTo.Priority = 1;
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
