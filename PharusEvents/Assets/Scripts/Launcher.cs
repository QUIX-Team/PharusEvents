using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby();        
    }

    public override void OnJoinedLobby()
    {
        MenueManager.Instance.OpenMenue("title");
        Debug.Log("Joined lobby");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
