using UnityEngine;
using System.Collections;

using UnityEngine.Networking;
public class PlayerController1 : NetworkBehaviour {
	public float maxVelocity;
	public float minVelocity;
	public float rotationRate;
	public float strafeAcceleration;
	public float jumpStrength;
	public float turnRotationAngle;
	public float turnRotationSeekSpeed;
    public bool canMove;

	private float rotationVelocity;
	private float groundAngleVelocity;


	private Rigidbody rb;
	// Use this for initialization
	void Start () {
        
		rb = GetComponent<Rigidbody> ();
        canMove = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        //if (!(canMove && PlayerPrefs.GetFloat ("start") == 1))
		//	return;

        Vector3 newRotation;
        print(rb.velocity.magnitude);
        if (Physics.Raycast(transform.position, -this.transform.up, 4.0f))
        {
            rb.drag = 1;
            Vector3 forwardForce = transform.forward * maxVelocity * 50.0f * Input.GetAxis("Vertical");
            forwardForce = forwardForce * Time.deltaTime * rb.mass;
            rb.AddForce(forwardForce);
            //rb.AddRelativeForce (Input.GetAxis ("Strafe") * new Vector3 (strafeAcceleration, 0.0f, 0.0f) * Time.deltaTime * rb.mass);
            //if ((transform.rotation * rb.velocity).z < minVelocity)
            //rb.AddRelativeForce (new Vector3 (0.0f, 0.0f, minVelocity * rb.drag * 50 * Time.deltaTime * rb.mass));
        }
        else
        {
            rb.drag = 0;
            newRotation = transform.eulerAngles;
            newRotation.x = Mathf.SmoothDampAngle(newRotation.x, 0.0f, ref rotationVelocity, turnRotationSeekSpeed);
            newRotation.z = Mathf.SmoothDampAngle(newRotation.z, 0.0f, ref rotationVelocity, turnRotationSeekSpeed);
            transform.eulerAngles = newRotation;
        }

        Vector3 turnTorque = transform.up * rotationRate * Input.GetAxis("Horizontal");
        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);
    }

    
}
