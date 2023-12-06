using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRed : MonoBehaviour
{
    [SerializeField] int _Value;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        GameManager.instance.handlingScore(false,_Value);
        gameObject.SetActive(false);
        other.GetComponent<Player>().displayScoreIncrement("" +_Value);
    }
}
