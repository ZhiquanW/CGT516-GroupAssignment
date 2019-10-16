using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetWorkManager : MonoBehaviourPunCallbacks {

    public Button BtnConnectMaster;
    public Button BtnConnectRoom;

    public bool triesToConnectToMaster;
    public bool triesToConnectToRoom;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        triesToConnectToMaster = false;
        triesToConnectToRoom = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (BtnConnectMaster != null)
            BtnConnectMaster.gameObject.SetActive(!PhotonNetwork.IsConnected && !triesToConnectToMaster);
        if (BtnConnectRoom != null)
            BtnConnectRoom.gameObject.SetActive(PhotonNetwork.IsConnected && !triesToConnectToMaster && !triesToConnectToRoom); 
	}

    public void OnClickConnectToMaster()
    {
        PhotonNetwork.OfflineMode = false;
        PhotonNetwork.NickName = "PlayerName";
        //PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "v1";

        triesToConnectToMaster = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        triesToConnectToMaster = false;
        triesToConnectToRoom = false;
        Debug.Log(cause);
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        triesToConnectToMaster = false;
        Debug.Log("Connected to Master");
    }

    public void OnClickConnectToRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        triesToConnectToRoom = true;
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        triesToConnectToRoom = false;
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + "| Players In Room: " + PhotonNetwork.CurrentRoom.Name);

        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log(message);
        triesToConnectToRoom = false;
    }
}
