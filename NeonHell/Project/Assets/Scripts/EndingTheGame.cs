using UnityEngine;
using System.Collections;

public class EndingTheGame : MonoBehaviour {
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (other.gameObject.tag == "Finish") {
			Destroy (other.gameObject);
		}
	}
}
