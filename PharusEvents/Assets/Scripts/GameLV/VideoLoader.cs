using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    
    public VideoPlayer videoPlayer;
    public string videoUrl = @"C:\Users\Interface\Desktop\l\College\NN\1.mp4";
     
     public static VideoLoader Instance;

     void Awake()
     {
         Instance = this;
     }
    void Start()
    {
        videoPlayer.url = videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack (0, true);
        videoPlayer.Prepare();
    }
    public void ReSetVideo()
    {
        videoPlayer.url = videoUrl;
        videoPlayer.Prepare();
    }
    public void Pause()
    {
        Debug.Log("Video pause");
        videoPlayer.Pause();
    }
    public void Play()
    {
        Debug.Log("Video play");
        videoPlayer.Play();
    }
}
