using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI _scoreText;
    public TMP_Text _userName;
    public GameObject _winMenu;
    public GameObject _overMenu;
    public TMP_Text _dollarScore;
    
    public static UI instance;

    private void Awake() 
    {
        instance = this;
    }

    private void Start()
    {
        _userName.text = PlayerPrefs.GetString("user_name");
    }

    //hide the menu and update the the game state
    public void buttonStart()
    {
        int childCount = gameObject.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }
        GameManager.instance._state = gameState.runing;
        _scoreText.text = GameManager.instance._score +"/"+ GameManager.instance._amountToCollect +"$";
    }
}
