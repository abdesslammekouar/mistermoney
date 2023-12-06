using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    private void Update() 
    {
        transform.position += new Vector3(0,_speed* Time.deltaTime,0);
        if(transform.position.y < -4)
        {
            Destroy(gameObject,1);
        } 
    }
}
