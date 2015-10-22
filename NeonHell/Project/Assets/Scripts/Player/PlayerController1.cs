using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {
	public float acceleration;
	public float rotationRate;

	public float turnRotationAngle;
	public float turnRotationSeekSpeed;

	private float rotationVelocity;
	private float groundAngleVelocity;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(Physics.Raycast(transform.position, - this.transform.up, 3.0f)){
			rb.drag = 1.0f;
			Vector3 forwardForce = transform.forward * acceleration * Input.GetAxis("Vertical");
			forwardForce = forwardForce * Time.deltaTime * rb.mass;
			rb.AddForce(forwardForce);
		}
		else{
			rb.drag = 0;
		}

		Vector3 turnTorque = Vector3.up * rotationRate * Input.GetAxis("Horizontal");
		turnTorque = turnTorque * Time.deltaTime * rb.mass;
		rb.AddTorque(turnTorque);

		Vector3 newRotation = transform.eulerAngles;
		newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
		transform.eulerAngles = newRotation;
	}
}
