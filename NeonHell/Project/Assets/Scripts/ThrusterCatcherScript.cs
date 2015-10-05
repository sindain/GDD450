using UnityEngine;
using System.Collections;

public class ThrusterCatcherScript : MonoBehaviour {

	public CenterThrusterScript cenThrust;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Arena") {
			cenThrust.gonnaGoUp ();
		}
	}
}
