using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
   [SerializeField] TMP_InputField input;

    void Start()
    {
        if(PlayerPrefs.HasKey("username"))
        {
            input.text = PlayerPrefs.GetString("username");
        }
        else
        {
            input.text = "player" + Random.Range(1,1000).ToString("0000");
            OnUserNameInputChange();
        }
    }

   public void OnUserNameInputChange()
   {
       PhotonNetwork.NickName = input.text;
       PlayerPrefs.SetString("username", input.text);
   }
}
