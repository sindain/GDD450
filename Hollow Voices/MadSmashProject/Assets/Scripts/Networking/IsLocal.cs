using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class IsLocal : NetworkBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
        {
            player.GetComponent<SimpleMovement>().canMove = true;
        }
	}
}
