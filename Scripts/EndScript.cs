using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highscore;

    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        score.text = PlayerPrefs.GetInt("Session Score").ToString();
        highscore.text = PlayerPrefs.GetInt("High Score").ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("High Score", gm.highScore);
    }
    public void MainMenu()
    {
        gm.MainMenu();
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
