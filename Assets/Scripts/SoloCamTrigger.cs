using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloCamTrigger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera TransitionFrom;
    [SerializeField] CinemachineVirtualCamera TransitionTo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TransitionFrom.Priority = 0;
        TransitionTo.Priority = 1;
        collision.gameObject.SetActive(false);
    }
}
