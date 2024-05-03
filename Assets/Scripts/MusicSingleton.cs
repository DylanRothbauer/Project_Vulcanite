using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSingleton : MonoBehaviour
{
    public static MusicSingleton Instance { get; private set; }
    public AudioSource src;
    public AudioClip menu;
    public AudioClip regular;
    public AudioClip finalBoss;
    public AudioClip sunset;
    private Scene currentScene;
    private int isPlaying = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Start Screen")
        {
            if (isPlaying != 1)
            {
                src.clip = menu;
                src.Play();
                isPlaying = 1;
            }
        }

        else if (currentScene.name == "FinalBossBeta")
        {
            if (isPlaying != 2)
            {
                src.clip = finalBoss;
                src.Play();
                isPlaying = 2;
            }
        }

        else if (currentScene.name == "LoseScene")
        {
            Debug.Log("Preparing to stop.");
            src.Stop();
            Debug.Log("Music should have stopped.");
        }

        else if (currentScene.name == "Win Screen")
        {
            if (isPlaying != 4)
            {
                src.clip = sunset;
                src.Play();
            }
            isPlaying = 4;
        }

        else
        {
            if (isPlaying != 3)
            {
                src.clip = regular;
                src.Play();
                isPlaying = 3;
            }
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
