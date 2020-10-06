using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    
    // Start is called before the first frame update
    void Start()
    {
        //play song on menu start
        if (_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }
    }
}
