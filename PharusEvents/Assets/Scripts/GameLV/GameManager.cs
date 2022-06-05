using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerInputActions inputActions;
    [SerializeField] Menu videolink;
    [SerializeField] TMP_InputField input;

     void Awake()
    {
        inputActions = new PlayerInputActions();
    }
     void OnEnable()
    {
        inputActions.Enable();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(inputActions.UI.ShowVideolink.triggered)
        {
            videolink.Open();
        }
        else if(inputActions.UI.HideVideoLink.triggered)
        {
            videolink.Close();
        }

        if(inputActions.UI.VideoPause.triggered)
        {
            VideoLoader.Instance.Pause();
        }
        if(inputActions.UI.VideoPlay.triggered)
        {
            VideoLoader.Instance.Play();
        }

    }

    public void OnVideoLinkChanged()
    {
        Debug.Log("On video link changed");
        VideoLoader.Instance.videoUrl = input.text;
        VideoLoader.Instance.ReSetVideo();
        videolink.Close();

    }
}
