using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveMyData : MonoBehaviour
{
    public static saveMyData instance;

    private void Awake() 
    {
        instance = this;
    }

    //saving data to playerPrefs
    public void saveName()
    {
        PlayerPrefs.SetString("LastScene",SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }

    public void saveScore()
    {
        int updatedScore = PlayerPrefs.GetInt("highscore") + GameManager.instance._amountToCollect;
        PlayerPrefs.SetInt("highscore",updatedScore);
        PlayerPrefs.Save();
    }

    public void saveAmountToCollect()
    {
        PlayerPrefs.SetInt("amountToCollect",GameManager.instance._amountToCollect);
        PlayerPrefs.Save();
    }
}
