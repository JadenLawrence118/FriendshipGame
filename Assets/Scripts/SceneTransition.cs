using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int sceneNo;
    [SerializeField] private GameObject[] targetCollisions;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < targetCollisions.Length; i++)
        {
            if (collision.gameObject == targetCollisions[i])
            {
                SceneManager.LoadScene(sceneNo);
            }
        }
    }
}
