using UnityEngine;
using System.Collections;

public class MinimapFollow : MonoBehaviour {

	public GameObject player;

	void Update(){
		transform.position = player.transform.position + new Vector3(-10,100-player.transform.position.y,0);
	}
}
