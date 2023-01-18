using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetWorkManagerPista1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public GameObject player2;

    public GameObject save1;
    public GameObject save2;
    public GameObject[] SpawnPoints;

    private PhotonView _photonView;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            Debug.Log("Player 1");

            save1 = PhotonNetwork.Instantiate(player.name, SpawnPoints[0].transform.position, SpawnPoints[0].transform.rotation);
        }
        else
        {
            Debug.Log("Player 2");

            save2 = PhotonNetwork.Instantiate(player2.name, SpawnPoints[1].transform.position, SpawnPoints[1].transform.rotation);
        }

    }

}
