using UnityEngine;
using System.Collections;

public class LeftWingScript : MonoBehaviour {

	public GameObject player;
	private bool rotatePlayer;
	public CenterThrusterScript cenThrust;

	/*void Update(){
		while (rotatePlayer) {
			player.transform.Rotate (new Vector3 (0, 0, -1));
			break;
		}
	}*/

	void OnTriggerEnter(Collider other){
		if (other.tag == "Arena") {
			rotatePlayer = true;
			StartCoroutine (Turning ());
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Arena") {
			rotatePlayer = false;
		}
	}

	IEnumerator Turning(){
		while (rotatePlayer) {
			player.transform.Rotate (new Vector3 (0, 0, -4));
			cenThrust.gonnaGoUp ();
			yield return new WaitForSeconds (0f);
		}
		//break;
	}
}
