using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    [SerializeField] Text _highScoreTextView;
    string HighScore = "HighScore";
    void Update()
    {
        //load high score display
        int highScore = PlayerPrefs.GetInt(HighScore);
        _highScoreTextView.text = highScore.ToString();
    }
    public void ResetData()
    {
        PlayerPrefs.SetInt(HighScore, 0);
    }
}
