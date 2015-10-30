using UnityEngine;
using System.Collections;

using UnityEngine.Networking;
public class PlayerController1 : NetworkBehaviour {

	//Public variables
	public float maxVelocity;
	public float minVelocity;
	public float rotationRate;
	public float strafeAcceleration;
	public float jumpStrength;
	public float turnRotationAngle;
	public float turnRotationSeekSpeed;
	public GameObject trackWaypoints;
	public bool canMove;

	//Private variables
	private int lap = 1;
	private float rotationVelocity;
	private float groundAngleVelocity;
	private GameObject currentPoint;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		currentPoint = trackWaypoints.transform.GetChild (0).GetComponent<WaypointController> ().getPoint();
		rb = GetComponent<Rigidbody> ();
        canMove = false;
	} //End void Start()
	
	// Update is called once per frame
	void Update () {
	
	} //End void Update()

    void FixedUpdate()
    {
        if (!(canMove && PlayerPrefs.GetFloat ("start") == 1))
			return;

		//Vector help keep the ship upright
        Vector3 newRotation;

		//If the player is close to the something, allow moving forward
        if (Physics.Raycast(transform.position, -this.transform.up, 4.0f)){
            rb.drag = 1;
            Vector3 forwardForce = transform.forward * maxVelocity * 50.0f * Input.GetAxis("Vertical");
            forwardForce = forwardForce * Time.deltaTime * rb.mass;
            rb.AddForce(forwardForce);
            //rb.AddRelativeForce (Input.GetAxis ("Strafe") * new Vector3 (strafeAcceleration, 0.0f, 0.0f) * Time.deltaTime * rb.mass);
            //if ((transform.rotation * rb.velocity).z < minVelocity)
            //rb.AddRelativeForce (new Vector3 (0.0f, 0.0f, minVelocity * rb.drag * 50 * Time.deltaTime * rb.mass));
		} //End if (Physics.Raycast(transform.position, -this.transform.up, 4.0f))

		//If the player isn't close to something
		else{
            rb.drag = 0;
			//The following 4 lines help keep the ship upright while in midair
            newRotation = transform.eulerAngles;
            newRotation.x = Mathf.SmoothDampAngle(newRotation.x, 0.0f, ref rotationVelocity, turnRotationSeekSpeed);
            newRotation.z = Mathf.SmoothDampAngle(newRotation.z, 0.0f, ref rotationVelocity, turnRotationSeekSpeed);
            transform.eulerAngles = newRotation;
        } //End else

		//Apply torque, e.g. turn the ship left and right
        Vector3 turnTorque = transform.up * rotationRate * Input.GetAxis("Horizontal");
        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);
	} // End void FixedUpdate()
	
	public void nextPoint(){
		//If we hit the finish line, increment laps and such
		if (currentPoint.GetComponent<WaypointController> ().getNextPoint ().Equals (trackWaypoints.transform.GetChild (0).GetComponent<WaypointController> ().getPoint ())) {
			lap ++;
			if(lap >= 2)
				print ("You win");
		} // End if (currentPoint.GetComponent ...
		currentPoint = currentPoint.GetComponent<WaypointController> ().getNextPoint ();
	} //End public void nextPoint()

	public int getLap(){
		return lap;
	} //End public int getLap()

	public void setLap(int pLap){
		lap = pLap;
	} // End public void setLap(int pLap)
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Waypoint" && other.gameObject.Equals(currentPoint.GetComponent<WaypointController> ().getNextPoint ()))
			nextPoint ();
	} // End void OnTriggerEnter(Collider other)
	
    
}
