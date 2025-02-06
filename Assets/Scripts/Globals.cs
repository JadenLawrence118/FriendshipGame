using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private bool destroyOnLoad = false;

    public Vector2 spawnPos;
    public bool paused = false;

    private static Globals self;

    public AudioSource pauseClip;
    public AudioSource resumeClip;

    void Awake()
    {
        if (!destroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }

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
