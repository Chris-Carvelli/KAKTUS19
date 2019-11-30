using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameConfig _config;
    [Header("Game Variables")]
    [Tooltip("How many cubes to spawn before considering a game over.")]
    public int _maxCubes;
    [Tooltip("The time interval between cubes spawning")]
    public float _spawnRate;
    [Tooltip("The Spawner of Cubes")]
    public Spawner _spawner;

    [Header("UI")]
    [Tooltip("The counter that shows how many cubes are left")]
    public Text _cubeCounter;

    // Private Variables
    private int _remainingCubes;
    private float _elapsedTime = 0.0f;
    private bool _canSpawnCubes = true;

    void Start()
    {
        _remainingCubes = _maxCubes;
    }

    void Update()
    {
        if (_canSpawnCubes == true)
        {
            if (_elapsedTime < _spawnRate)
            {
                _elapsedTime += Time.deltaTime;
                if(_elapsedTime >= _spawnRate)
                {
                    //_spawner
                    _remainingCubes -= 1;
                    _cubeCounter.text = $"{_remainingCubes}";
                }
            }
        }
    }
}
