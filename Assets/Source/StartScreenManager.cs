using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KAKTUS19
{
    public class StartScreenManager : MonoBehaviour
    {
        public void StartGame(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }

}