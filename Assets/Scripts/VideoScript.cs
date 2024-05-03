using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{

    [SerializeField] public string videoFileName;

    //public IEnumerator WaitForMovieEnd()
    //{
    //    while (video.isPlaying)
    //    {
    //        yield return new WaitForEndOfFrame();

    //    }
    //    OnMovieEnded();
    //}

    //void OnMovieEnded()
    //{
    //    SceneManager.LoadScene("PreFirst");
    //}

    //void Awake()
    //{
    //    video = GetComponent<VideoPlayer>();
    //    video.Play();
    //    





private void Start()
    {
        PlayVideo();
    }

    private void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
            videoPlayer.loopPointReached += CheckOver;
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("PreFirst");//the scene that you want to load after the video has ended.
    }
}
