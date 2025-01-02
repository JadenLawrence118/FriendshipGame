using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public Vector2 spawnPos;
    public bool paused = false;

    private static Globals self;
    void Awake()
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
}
