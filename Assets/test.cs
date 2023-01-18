using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.GetComponent<PhotonView>().IsMine)
        {
            PhotonNetwork.Destroy(transform.gameObject);
        }
        else
        {
            transform.gameObject.SetActive(false);
            UnityEngine.Object.Destroy(transform.gameObject, 1f);
        }
    }

   
}
