using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {
	public float maxVelocity;
	public float minVelocity;
	public float rotationRate;
	public float strafeAcceleration;
	public float jumpStrength;

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
		print (rb.velocity.magnitude);
		if (Physics.Raycast (transform.position, - this.transform.up, 4.0f)) {
			rb.drag = 1;
			//rb.AddRelativeForce (Input.GetAxis ("Jump") * new Vector3 (0.0f, jumpStrength, 0.0f) * Time.deltaTime * rb.mass);
			Vector3 forwardForce = transform.forward * maxVelocity * 50.0f * Input.GetAxis ("Vertical");
			forwardForce = forwardForce * Time.deltaTime * rb.mass;
			rb.AddForce (forwardForce);
			rb.AddRelativeForce(Input.GetAxis("Strafe") * new Vector3(strafeAcceleration,0.0f,0.0f) * Time.deltaTime * rb.mass);
			if((transform.rotation * rb.velocity).z < minVelocity)
				rb.AddRelativeForce(new Vector3(0.0f,0.0f, minVelocity * rb.drag * 50 * Time.deltaTime * rb.mass));
		} else
			rb.drag = 0;

		


		Vector3 turnTorque = transform.up * rotationRate * Input.GetAxis("Horizontal");
		turnTorque = turnTorque * Time.deltaTime * rb.mass;
		rb.AddTorque(turnTorque);

		Vector3 newRotation = transform.eulerAngles;
		newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
		transform.eulerAngles = newRotation;

	}
}
