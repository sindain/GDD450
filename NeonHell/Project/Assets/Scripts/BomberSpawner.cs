using UnityEngine;
using System.Collections;

public class BomberSpawner : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject.Find ("Bomber 1").transform.position = transform.position;
			GameObject.Find ("Bomber 1").transform.rotation = transform.rotation;
		}
	}
}
