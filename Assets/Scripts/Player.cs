using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Player : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] int _maxPos;
    [SerializeField] int _minPos;
    [SerializeField] PlayerAnimation _animation;
    Rigidbody2D _playerRigid;
    [SerializeField] GameObject _uiIncrement;
    [SerializeField] TextMeshProUGUI _uiIncrementText;

    //activate or deactivate the player rigid body
    private void Start() 
    {
        _playerRigid = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if(GameManager.instance._state == gameState.runing)
        {
            _playerRigid.simulated = true;
        }
        else
        {
            _playerRigid.simulated = false;
        }
    }

    //calculate the offset between camera and the player
    private void OnMouseDown() 
    {
        _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //update the player movement
    private void OnMouseDrag() 
    {
        if(GameManager.instance._state == gameState.runing)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
            transform.position = new Vector3(math.clamp(newPos.x,_minPos,_maxPos),transform.position.y,transform.position.z);
            _animation.animationControl();
        }
    }

    //control the popup score on the top of the player
    public void displayScoreIncrement(string value)
    {
        _uiIncrement.SetActive(true);
        _uiIncrementText.text = value; 
        Invoke("uiIncrementDisplay",0.8f);
    }
    void uiIncrementDisplay()
    {
        _uiIncrement.SetActive(false);
    }
}
