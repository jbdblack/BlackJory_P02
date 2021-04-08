using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //[SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;

    void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // load high score display
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();


        /*// play starting song on menu start
        if(_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }*/
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        Debug.Log("High Score Reset");
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
    }
}
