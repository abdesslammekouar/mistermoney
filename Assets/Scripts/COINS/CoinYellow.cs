using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinYellow : MonoBehaviour
{
    [SerializeField] int _Value;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        GameManager.instance.handlingScore(true,_Value);
        gameObject.SetActive(false);
        other.GetComponent<Player>().displayScoreIncrement("+" +_Value);
    }
}
