using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_InputField roomName_Input;
    [SerializeField] TMP_Text error_txt;
    [SerializeField] TMP_Text roomName_txt;

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

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomName_Input.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomName_Input.text);
        MenueManager.Instance.OpenMenue("loading");
    }

     public override void OnJoinedRoom()
    {
        roomName_txt.text = PhotonNetwork.CurrentRoom.Name;
        MenueManager.Instance.OpenMenue("room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        error_txt.text = "Room creation failed!\n" + message;
        MenueManager.Instance.OpenMenue("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenueManager.Instance.OpenMenue("loading");
    }

    public override void OnLeftRoom()
    {
        MenueManager.Instance.OpenMenue("title");
    }
}
