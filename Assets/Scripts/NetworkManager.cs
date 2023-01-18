using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    /// &lt;summary&gt;
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// &lt;/summary&gt;
    string gameVersion = "1";

    // Reference to the join room button
    [SerializeField] private Button joinRoomButton;
    [SerializeField] private Button joinRoomButton2;

    [SerializeField]
    private byte maxPlayersPerRoom = 2;


    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField]
    public GameObject controlPanel;
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    public GameObject progressLabel;


    public GameObject av;

    bool onetime = false;
    /// &lt;summary&gt;
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// &lt;/summary&gt;
    /// 
    Photon.Pun.Demo.PunBasics.PlayerNameInputField p;
    void Awake()
    {
        //PlayerPrefs.DeleteAll();

        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    private void Start()
    {
        p = new Photon.Pun.Demo.PunBasics.PlayerNameInputField();
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }


    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && onetime == false)
                {
                    joinRoomButton2.gameObject.SetActive(true);
                }
            }
        }




    }

    /// &lt;summary&gt;
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// &lt;/summary&gt;
    public void Connect()
    {
        p.SetPlayerName(controlPanel.transform.GetChild(1).GetComponent<InputField>().text);

        joinRoomButton.interactable = false;
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);


        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            //PhotonNetwork.GameVersion = gameVersion;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);

        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });


    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

        joinRoomButton.gameObject.SetActive(false);

        //if (PhotonNetwork.CountOfPlayers == 2)
        //{
        //    Debug.Log("FindMatch");

        //    SceneManager.LoadScene(1);

        //}

    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("entrou");

       
    }


    public void startGame()
    {

        //only the master client may load the level.

        PhotonNetwork.LoadLevel("Pista1");

        //PhotonNetwork.Instantiate(av.name, av.transform.position , Quaternion.identity , 0);
        //GameObject GameObject = PhotonNetwork.Instantiate(av.name,av.transform.position,av.transform.rotation);        
    }






}
