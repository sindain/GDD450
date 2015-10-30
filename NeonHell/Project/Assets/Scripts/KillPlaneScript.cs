using UnityEngine;
using System.Collections;

public class KillPlaneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			col.transform.position= new Vector3(0,10,0);
			col.transform.rotation= new Quaternion(0,0,0,0);
			col.attachedRigidbody.velocity = Vector3.zero;
			col.attachedRigidbody.angularVelocity = Vector3.zero;

		}
	}
}
