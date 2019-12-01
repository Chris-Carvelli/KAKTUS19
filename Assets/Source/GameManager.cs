
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [Tooltip("Time to slow down the timescale to 0")]
    public float _timeScaleSlowdown;

    [Header("UI")]
    [Tooltip("The counter that shows how many cubes are left")]
    public Text _cubeCounter;
    [Tooltip("The time it takes to fade out the cube counter at the end of the game")]
    public float _cubeCounterFadeoutTime;
    [Tooltip("The end screen object")]
    public GameObject _endScreen;
    [Tooltip("The time it takes for the endscreen to slide into view")]
    public float _endScreenTweenTime;
    [Tooltip("The end screen total counter")]
    public Text _endScreenTotalCounter;
    [Tooltip("The time for each endscreen score count step")]
    public float _endScreenTotalCounterStep;
    [Tooltip("After the last cube is sent, how long to wait before showing end screen")]
    public float _endScreenWaitTime;

    // Private Variables
    private Platform[] _platforms;
    private int _remainingCubes;
    private float _elapsedTime = 0.0f;
    private bool _canSpawnCubes = true;
    private bool _waitingForEndScreen = false;
    private bool _gameIsOver = false;

    void Start()
    {
        _platforms = FindObjectsOfType<Platform>();
        _remainingCubes = _maxCubes;
        _cubeCounter.text = $"{_remainingCubes}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (_canSpawnCubes == true)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _spawnRate)
            {
                _spawner.RandomSpawn();
                _remainingCubes -= 1;
                _cubeCounter.text = $"{_remainingCubes}";
                _elapsedTime = 0.0f;
                if (_remainingCubes <= 0)
                {
                    _cubeCounter.text = "0";
                    _canSpawnCubes = false;
                    _waitingForEndScreen = true;
                    _elapsedTime = 0.0f;
                }
            }
        }
        if (_waitingForEndScreen == true)
        {
            if (_elapsedTime < _endScreenWaitTime)
            {
                _elapsedTime += Time.deltaTime;
            }

            if (_elapsedTime >= _endScreenWaitTime)
            {
                StartCoroutine(SlowTime());
                StartCoroutine(FadeoutCubeCounter());
                StartCoroutine(ShowEndscreen());
                _waitingForEndScreen = false;
                _gameIsOver = true;
            }
        }
    }

    public IEnumerator FadeoutCubeCounter()
    {
        _cubeCounter.CrossFadeAlpha(0.0f, _cubeCounterFadeoutTime, false);
        yield return null;
    }

    public IEnumerator SlowTime()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < _timeScaleSlowdown)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float alpha = elapsedTime / _timeScaleSlowdown;
            float lerpTime = Mathf.Lerp(1.0f, 0.0f, alpha);
            Time.timeScale = lerpTime;
            yield return null;
        }
        Time.timeScale = 0.0f;
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
            elapsedTime += Time.unscaledDeltaTime;
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
        int finalScore = 0;
        for (int index = 0; index < _platforms.Length; index++)
        {
            finalScore += _platforms[index].CountColors();
        }

        if (finalScore < 0)
        {
            finalScore = 0;
        }
        else
        {
            int elapsedScore = 0;
            while (elapsedScore < finalScore)
            {
                elapsedScore += 1;
                _endScreenTotalCounter.text = $"{elapsedScore}";
                yield return new WaitForSeconds(_endScreenTotalCounterStep);
            }
        }
        _endScreenTotalCounter.text = $"{finalScore}";
        yield return null;
    }
}