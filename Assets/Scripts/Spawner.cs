using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] _coins;
    [SerializeField] GameObject[] _coinsExtra;
    [SerializeField] float _spawnRate;
    [SerializeField] int _minSpawnRange;
    [SerializeField] int _maxSpawnRange;
    [SerializeField] float _dropChance;
    int _randomSpawnPos = 0;
    int _lastRandomSpawnPos = 0;

    private void Start() 
    {
        StartCoroutine(spawnCoins());    
    }

    IEnumerator spawnCoins()
    {
        while(this != null)
        {
            if(GameManager.instance._state == gameState.runing)
            {
                //to prevent spawning in the same place
                while(_randomSpawnPos == _lastRandomSpawnPos)
                {
                    _randomSpawnPos = UnityEngine.Random.Range(_minSpawnRange,_maxSpawnRange);
                }
                _lastRandomSpawnPos = _randomSpawnPos;
                
                //generate a drop chance for the bag 
                Vector3 spawnPos = new Vector3(_randomSpawnPos,transform.position.y,transform.position.z);
                System.Random rand = new System.Random();
                float randomValue = (float)rand.NextDouble();

                if(randomValue < _dropChance)
                {
                    Instantiate(_coinsExtra[UnityEngine.Random.Range(0,_coinsExtra.Length)],spawnPos,quaternion.identity);
                }
                else
                {
                    Instantiate(_coins[UnityEngine.Random.Range(0,_coins.Length)],spawnPos,quaternion.identity);
                } 
            }
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
