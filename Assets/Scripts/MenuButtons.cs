using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadInstr()
    {
        SceneManager.LoadScene(2);
    }
    public void BackHome()
    {
        SceneManager.LoadScene(1);
    }
}
