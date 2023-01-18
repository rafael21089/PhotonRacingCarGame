using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ConnectingPlayers : MonoBehaviourPunCallbacks
{
    /// &lt;summary&gt;
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// &lt;/summary&gt;
    string gameVersion = "1";

    [SerializeField]
    private byte maxPlayersPerRoom = 2;


    public GameObject player;
    public GameObject player2;
    public GameObject[] SpawnPoints;


    /// 
    void Awake()
    {
        //PlayerPrefs.DeleteAll();

        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    private void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();

    }
    /// &lt;summary&gt;
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// &lt;/summary&gt;


    //public override void OnJoinedRoom()
    //{
    //    Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

    //    Debug.Log(PhotonNetwork.CountOfPlayers);

    //    Debug.Log(PlayerPrefs.GetString("PlayerName"));

    //    Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
    //    if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
    //    {
    //        Debug.Log("Player 1");

    //        Instantiate(player, SpawnPoints[0].transform.position, SpawnPoints[0].transform.rotation);
    //    }
    //    else
    //    {
    //        Debug.Log("Player 2");
    //        Instantiate(player2, SpawnPoints[1].transform.position, SpawnPoints[1].transform.rotation);
    //    }

    //}

    public override void OnJoinedRoom()
    {
        Debug.Log("naice1");

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("naice");

    }
}
