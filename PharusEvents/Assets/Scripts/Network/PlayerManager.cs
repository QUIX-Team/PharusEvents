using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView pv;
    
    void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(pv.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void CreateController()
    {
        Transform spawnPoint = SpawnManager.Instance.GetSpawnPoint();

        if(PlayerPrefs.GetString("avatar") == Settings.JOSH || PlayerPrefs.GetString("avatar") is null )
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerController"),spawnPoint.position,spawnPoint.rotation);
        }

        else if (PlayerPrefs.GetString("avatar") == Settings.SUZIE)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","SuziePlayerController"),spawnPoint.position,spawnPoint.rotation);
        }
    }
}
