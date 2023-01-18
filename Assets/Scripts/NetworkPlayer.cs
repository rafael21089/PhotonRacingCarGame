using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayer : MonoBehaviour
{
    public GameObject localCam;
    public GameObject localCam2;

    public GameObject canvas;
    public GameObject sound;

    public ParticleSystem particulas;
    public ParticleSystem particulas2;

    public static GameObject LocalPlayerInstance;

    private PhotonView _photonView;

   

    private void Start()
    {
        _photonView = this.GetComponent<PhotonView>();

        if (_photonView.IsMine)
        {
            localCam.SetActive(true);
            localCam2.SetActive(true);
            canvas.SetActive(true);
            sound.SetActive(true);

        }
        else
        {
            localCam.SetActive(false);
            localCam2.SetActive(false);
            canvas.SetActive(false);
            sound.SetActive(false);

        }

    }




}
