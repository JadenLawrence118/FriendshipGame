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
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        SceneManager.LoadScene(1);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(5);
    }
    public void Resume()
    {
        GameObject.Find("PauseMenu").SetActive(false);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>().paused = false;
        Time.timeScale = 1.0f;
    }
    public void ResetPuzzle()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(3);
    }
}
