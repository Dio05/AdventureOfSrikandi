using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] Score scoreScript;

    [SerializeField] PlayerController ngulang;

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void jawaban()
    {
        scoreScript.addScorelvl1();
        
    }

    public void jawaban2()
    {
        scoreScript.addScorelvl2();
    }

    public void jawaban3()
    {
        scoreScript.addScorelvl3();
    }

    public void jawaban3a()
    {
        scoreScript.addScorelvl3a();
    }

    public void Jsalah()
    {
        SceneManager.LoadScene("Level1");
    }
}
