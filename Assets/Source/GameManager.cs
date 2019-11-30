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
    [Tooltip("All the platforms in the game")]
    public GameObject[] _platforms;

    [Header("UI")]
    [Tooltip("The counter that shows how many cubes are left")]
    public Text _cubeCounter;
    [Tooltip("The time it takes to fade out the cube counter at the end of the game")]
    public float _cubeCounterFadeoutTime;
    [Tooltip("The endscreen object")]
    public GameObject _endScreen;
    [Tooltip("The time it takes for the endscreen to slide into view")]
    public float _endScreenTweenTime;
    [Tooltip("The ")]

    // Private Variables
    private int _remainingCubes;
    private float _elapsedTime = 0.0f;
    private bool _canSpawnCubes = true;

    void Start()
    {
        _remainingCubes = _maxCubes;
        _cubeCounter.text = $"{_remainingCubes}";
    }

    void Update()
    {
        if (_canSpawnCubes == true)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _spawnRate)
            {
                //_spawner.spawn()
                _remainingCubes -= 1;
                _cubeCounter.text = $"{_remainingCubes}";
                _elapsedTime = 0.0f;
                if (_remainingCubes <= 0)
                {
                    _cubeCounter.text = "0";
                    _canSpawnCubes = false;
                    StartCoroutine(FadeoutCubeCounter());
                    StartCoroutine(ShowEndscreen());
                }
            }
        }
    }

    public IEnumerator FadeoutCubeCounter()
    {
        _cubeCounter.CrossFadeAlpha(0.0f, _cubeCounterFadeoutTime, false);
        yield return null;
    }

    public IEnumerator ShowEndscreen()
    {
        float elapsedTime = 0.0f;
        float screenHorizontalCenter = 0.0f;// Screen.width * 0.5f;
        RectTransform endScreenTransformRect = _endScreen.GetComponent<RectTransform>();
        float endScreenStartHorizontalPos = endScreenTransformRect.localPosition.x;
        float endScreenStartVerticalPos = endScreenTransformRect.localPosition.y;
        while (elapsedTime < _endScreenTweenTime)
        {
            // Insert tween logic here
            elapsedTime += Time.deltaTime;
            float alpha = elapsedTime / _endScreenTweenTime;
            float newHorizontalPos = Mathf.Lerp(endScreenStartHorizontalPos, screenHorizontalCenter, alpha);
            Vector2 newPosition = new Vector2(newHorizontalPos, endScreenStartVerticalPos);
            endScreenTransformRect.localPosition = newPosition;
            yield return null;
        }
        endScreenTransformRect.localPosition = new Vector2(screenHorizontalCenter, endScreenStartVerticalPos);
        StartCoroutine(StartBoxCounting());
        yield return null;
    }

    public IEnumerator StartBoxCounting()
    {
        float finalScore = 0.0f;
        float elapsedScore = 0.0f;
        // count points here
        // ...
        //while (elapsedScore < finalScore)
        //{
        //    elapsedScore +=
        //    float alpha = elapsedScore / finalScore;
        //}
        yield return null;
    }
}
