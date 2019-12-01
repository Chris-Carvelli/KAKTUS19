using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public FMOD.Studio.EventInstance SplashMusic;
    public FMOD.Studio.EventInstance GameMusic;
    public FMOD.Studio.EventInstance BackgroundNoise;



    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        SplashMusic = FMODUnity.RuntimeManager.CreateInstance("event:/SplashMusic");
        GameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/GameMusic");
        BackgroundNoise = FMODUnity.RuntimeManager.CreateInstance("event:/BackgroundNoise");
    }
  

    // Start is called before the first frame update
    void Start()
    {
        SplashMusic.start();
        BackgroundNoise.start();
    }

    // Update is called once per frame
    void Update()
    { }


    public void ChangeToGameMusic()
    {
        SplashMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        GameMusic.start();
    }

    public void MusicGameOver()
    {
        GameMusic.setParameterByName("GameDone", 1);
    }

    public void MusicRestart()
    {
        GameMusic.setParameterByName("GameDone", 0);
    }
}
