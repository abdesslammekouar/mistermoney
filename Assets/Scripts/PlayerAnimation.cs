using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Vector3 _lastPosition;
    [SerializeField] Animator _anim;

    private void Start() 
    {
        _lastPosition = Input.mousePosition;
    }

    public void animationControl()
    {
        if(Input.mousePosition.x *1000f > _lastPosition.x *1000f)
        {
            _anim.SetBool("isIdle",false);
            transform.localScale = new Vector3(0.1342619f,transform.localScale.y,transform.localScale.z);
        }
        else if(_lastPosition.x *1000f > Input.mousePosition.x *1000f)
        {
            _anim.SetBool("isIdle",false);
            transform.localScale = new Vector3(-0.1342619f,transform.localScale.y,transform.localScale.z);
        }
        else if(Input.mousePosition.x *1000f - _lastPosition.x *1000f == 0)
        {
            _anim.SetBool("isIdle",true);
            Debug.Log(Input.mousePosition.x);
        }

        _lastPosition = Input.mousePosition;
    }
}
