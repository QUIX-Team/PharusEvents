using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    
    public VideoPlayer videoPlayer;
    public string videoUrl = "yourvideourl";
     
    void Start()
    {
        videoPlayer.url = videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack (0, true);
        videoPlayer.Prepare();
    }
    public void Pause()
    {
        videoPlayer.Pause();
    }
    public void Play()
    {
        videoPlayer.Play();
    }
}
