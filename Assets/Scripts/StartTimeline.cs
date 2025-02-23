using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartTimeline : MonoBehaviour
{
    private bool activated;

    void Update()
    {
        if (!activated)
        {
            if (gameObject.GetComponent<Interactables>().activated >= gameObject.GetComponent<Interactables>().activeNeeded)
            {
                activated = true;
                StartCoroutine(WaitToStart());
            }
        }
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSecondsRealtime(2f);
        GetComponent<PlayableDirector>().Play();
    }
}
