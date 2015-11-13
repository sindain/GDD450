using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class IsLocal : NetworkBehaviour {

    public GameObject shipCam;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
        {
            //shipCam.GetComponent<NetworkedCameraScript>().canRender = true;
        }
        if (PlayerPrefs.GetFloat("multi") == 0)
        {
            //shipCam.GetComponent<NetworkedCameraScript>().canRender = true;
        }
	}
}
