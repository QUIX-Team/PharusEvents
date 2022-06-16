using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Photon.Pun.PhotonNetwork.LoadLevel(0);
    }
}
