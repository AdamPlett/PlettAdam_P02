using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject _MenuPanel;
    [SerializeField] GameObject _Crosshair;
    int _currentScore;
    string HighScore = "HighScore";
    void Update()
    {
        //brings up pop up menu
        if ((Input.GetKeyDown(KeyCode.Escape)) && (_MenuPanel.activeSelf == false) )
        {
            PopUpMenu();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (_MenuPanel.activeSelf == true))
        {
            Resume();
        }
        //increase score
        //TODO replace with real implementation later
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
    }
    public void IncreaseScore(int ScoreIncrease)
    {
        //increase score
        _currentScore += ScoreIncrease;
        //update socre display, so we can see the new scoer
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }
    public void ExitLevel()
    {
        //compare score to highscore
        int highScore = PlayerPrefs.GetInt(HighScore);
        if (_currentScore > highScore)
        {
            //save as new highscore
            PlayerPrefs.SetInt(HighScore, _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        //load main menu scene
        SceneManager.LoadScene("MainMenu");
    }
    public void PopUpMenu()
    {
        //makes pop up menu visible
        _MenuPanel.SetActive(true);
        //TODO unlock and unhide cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _Crosshair.SetActive(false);
    }
    public void Resume()
    {
        //makes pop up menu disappear
        _MenuPanel.SetActive(false);
        //TODO lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("cursor should be locked");
        _Crosshair.SetActive(true);
    }
}
