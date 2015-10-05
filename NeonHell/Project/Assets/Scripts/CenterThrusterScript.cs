using UnityEngine;
using System.Collections;

public class CenterThrusterScript : MonoBehaviour {

	public PlayerController player;
	public bool goingUp;

	void Update(){
		//Debug.Log (goingUp);
	}

	public void gonnaGoUp(){
		if (!goingUp) {
			goingUp = true;
			StartCoroutine (SwitchToUp ());
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Arena") {
			if (goingUp) {
				goingUp = false;
				StartCoroutine (SwitchToDown ());
			}
		}
	}
	IEnumerator SwitchToDown(){
		while (!goingUp) {
			player.vSpeed -= .01f;
			yield return new WaitForSeconds (.01f);
			//Debug.Log ("fuck");
		}
		//break;
	}
	IEnumerator SwitchToUp(){
		while (goingUp) {
			player.vSpeed += .01f;
			yield return new WaitForSeconds (.01f);
			//Debug.Log ("fuck");
		}
		//break;
	}
}
