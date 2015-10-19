using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float hMove = Input.GetAxis ("Horizontal");

		//rb.AddRelativeTorque (new Vector3(0.0f, hMove * 0.5f, 0.0f));

		rb.AddRelativeForce(new Vector3(0f,0f,500.0f));
	}
}
