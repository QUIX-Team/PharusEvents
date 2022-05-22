using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher Instance;

    [SerializeField] TMP_InputField roomName_Input;
    [SerializeField] TMP_Text error_txt;
    [SerializeField] TMP_Text roomName_txt;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;

    void Awake() 
    {
        Instance=this;
    }

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

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenueManager.Instance.OpenMenue("loading");
    }

    public override void OnLeftRoom()
    {
        MenueManager.Instance.OpenMenue("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for(int i =0; i < roomList.Count;i++)
        {
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }
}
