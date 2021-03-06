using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher Instance;

    [SerializeField] TMP_InputField roomName_Input;
    [SerializeField] TMP_Text error_txt;
    [SerializeField] TMP_Text roomName_txt;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject startEvent_btn;
    [SerializeField] Button CreateButton;
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
        PhotonNetwork.AutomaticallySyncScene = true; 
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        AndroidGUI();
        Debug.Log("Joined lobby");
        //PhotonNetwork.NickName = "player" + Random.Range(1,1000).ToString("0000");
    }

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomName_Input.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomName_Input.text);
        MenuManager.Instance.OpenMenu("loading");
    }

     public override void OnJoinedRoom()
    {
        roomName_txt.text = PhotonNetwork.CurrentRoom.Name;
        MenuManager.Instance.OpenMenu("room");

        foreach(Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        Player[] players = PhotonNetwork.PlayerList;
        for(int i =0 ;i < players.Length ;i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        startEvent_btn.SetActive(PhotonNetwork.IsMasterClient);
    }

    public void StartEvent()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startEvent_btn.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        error_txt.text = "Room creation failed!\n" + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
        AndroidGUI();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for(int i =0; i < roomList.Count;i++)
        {
            if(roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void Credits()
    {
        PhotonNetwork.LoadLevel(2);
    }

    public void AndroidGUI()
    {
        #if UNITY_ANDROID

            CreateButton.gameObject.SetActive(false);

        #endif
        #if UNITY_EDITOR

            CreateButton.gameObject.SetActive(true);
            
        #endif
        
    }
}
