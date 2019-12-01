using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public Camera _main;
    public Transform playText;
    public PlanetController _planetController;

    public bool _Play = true;

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Update()
    {
        _Play = Vector3.Dot(_main.transform.position, playText.forward) > 0.3f;
        if (_Play == true)
        {
            if (_planetController.accelMagnitude > 5)
            {
                StartGame(1);
            }
        }
        else
        {
            if (_planetController.accelMagnitude > 5)
            {
                Exit();
            }
        }
    }
}