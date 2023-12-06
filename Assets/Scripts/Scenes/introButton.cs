using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class introButton : MonoBehaviour
{
    [SerializeField] TMP_InputField _input;

    private void Awake() 
    {
        if(PlayerPrefs.GetString("LastScene") != string.Empty)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
        }
    }

    public void loadScene()
    {
        PlayerPrefs.SetString("user_name",_input.text);
        
        if(PlayerPrefs.GetString("user_name") != string.Empty)
        {
            Debug.Log(PlayerPrefs.GetString("user_name"));
            SceneManager.LoadScene("firstRun");
        }
    }
}
