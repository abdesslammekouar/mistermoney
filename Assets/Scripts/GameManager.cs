using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public enum gameState { start, runing}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() 
    {
        instance = this;
    }


    //VARIABLES TO CONTROL THE GAME
    [HideInInspector] public gameState _state = gameState.start;
    public int _score {get; private set;}
    public int _amountToCollect;

    private void Start() 
    {
        saveMyData.instance.saveName();
        UI.instance._dollarScore.text = PlayerPrefs.GetInt("highscore").ToString();
        if(PlayerPrefs.GetInt("amountToCollect") != 0)
        {
            _amountToCollect = PlayerPrefs.GetInt("amountToCollect");
            UI.instance._scoreText.text = "0/"+_amountToCollect+"$";
        }
    }
    //method triggers from the coins to handle score
    public void handlingScore(bool isIncreasing, int scoreValue)
    {
        _score += scoreValue;

        if(_score <= 0 || _score >= _amountToCollect)
        {
            gameFinish();
        }
        //Debug.Log(_score);

        else if(isIncreasing)
        {
            UI.instance._scoreText.text = _score +"/"+_amountToCollect+"$";
        }
        else if(_score > 0)
        {
            UI.instance._scoreText.text = _score+"/"+_amountToCollect+"$";
        }
    }

    void gameFinish()
    {
            if(_score <= 0)
            {
                UI.instance._scoreText.text = "0/"+_amountToCollect+"$";
                UI.instance._overMenu.SetActive(true);
                saveMyData.instance.saveAmountToCollect();
            }
            else
            {
                saveMyData.instance.saveScore();
                UI.instance._dollarScore.text = PlayerPrefs.GetInt("highscore").ToString();
                UI.instance._scoreText.text = _amountToCollect+"/"+_amountToCollect+"$";
                UI.instance._winMenu.SetActive(true);
                _amountToCollect += 50;
                saveMyData.instance.saveAmountToCollect();
            }
            _state = gameState.start;
            _score = 0;
            
    }
}
