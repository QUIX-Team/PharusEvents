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
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerController"),spawnPoint.position,spawnPoint.rotation);
    }
}
