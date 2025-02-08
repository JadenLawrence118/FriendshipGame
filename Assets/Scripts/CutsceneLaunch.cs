using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneLaunch : MonoBehaviour
{
    [SerializeField] private float launchDelay;
    [SerializeField] private Vector2 launchStrength;
    [SerializeField] private AudioSource launchSound;

    private bool activated = false;

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            if (gameObject.GetComponent<Interactables>().activated >= gameObject.GetComponent<Interactables>().activeNeeded)
            {
                StartCoroutine(Wait());
                activated = true;
            }
        }
        GetComponent<SpriteRenderer>().flipX = true;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(launchDelay);
        GetComponent<Rigidbody2D>().AddForce(launchStrength, ForceMode2D.Impulse);
        GetComponent<CutsceneBehaviour>().enabled = false;
        launchSound.Play();
    }
}
