using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Color32 hoverColour;
    [SerializeField] private Color32 startColour;
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
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Globals>().resumeClip.Play();
        Time.timeScale = 1.0f;
    }
    public void ResetPuzzle()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(3);
    }
    public void colourChange()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = hoverColour;
    }
    public void colourRevert()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = startColour;
    }
}
