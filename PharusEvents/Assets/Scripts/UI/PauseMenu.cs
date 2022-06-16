using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Menu menu;
    public void Pause()
    {
        menu.Open();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        menu.Close();
        Time.timeScale = 1f;
    }
    public void Back()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    
   
}
