using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] spawnPoints;
    public GameObject[] playerPrefabs;

    GameObject save;
    private void Start()
    {

        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn = playerPrefabs[0];


        Debug.Log(Resources.Load("Cube"));

        GameObject pl = PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
        save = pl;
        pl.GetComponent<PhotonView>().Owner.TagObject = pl;

    }

    private void Update()
    {
        if (this.GetComponent<PhotonView>() != null)
        {
            if (this.GetComponent<PhotonView>().IsMine)
            {
                this.GetComponent<PhotonView>().Owner.TagObject = save;
            }
            else
            {
                return;
            }
        }
       
    }


}
