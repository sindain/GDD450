using UnityEngine;
using System.Collections;

public class FollowPlayerArrow : MonoBehaviour {

	public GameObject player;

	private float height;
	
	void Start () {
		height = transform.position.y;
	}

	void Update () {
		transform.position = player.transform.position + new Vector3(-1.5f,height-player.transform.position.y,0);
		transform.rotation = player.transform.rotation;
		transform.Rotate (0, -90, 0);
	}
}
