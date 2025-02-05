using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudio : MonoBehaviour
{
    private static MenuAudio self;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Destroy(gameObject);
        }
    }
}
