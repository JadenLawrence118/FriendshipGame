using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticles : MonoBehaviour
{
    private List<GameObject> particleSystems = new List<GameObject>();
    private bool activated = false;
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            particleSystems.Add(transform.GetChild(i).gameObject);
        }
        print(particleSystems.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated) 
        {
            if (gameObject.GetComponent<Interactables>().activated >= gameObject.GetComponent<Interactables>().activeNeeded)
            {
                for (int i = 0; i < particleSystems.Count; i++)
                {
                    particleSystems[i].SetActive(true);
                }
                activated = true;
            }
            else
            {
                for (int i = 0; i < particleSystems.Count; i++)
                {
                    particleSystems[i].SetActive(false);
                }
            }
        }
    }
}
