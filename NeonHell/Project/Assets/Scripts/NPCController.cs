﻿using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

	public GameObject trackWaypoints;
	public float fTurnSpeed = 30;
	public float maxVelocity = 50.0f;

	private GameObject currentPoint;
	private int lap = 1;
	private Rigidbody rb;
	private GameObject direction;
	private int iAccelDir = 0;
	private float rotationVelocity;
	private bool canMove;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		currentPoint = trackWaypoints.transform.GetChild (0).GetComponent<WaypointController> ().getPoint();
		direction = new GameObject();
		//target = trackWaypoints.transform.GetChild (0).GetComponent<WaypointController> ().getPoint ().transform;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){


		//Update the direction that the NPC needs to go
		direction.transform.position = transform.position;
		direction.transform.eulerAngles = transform.eulerAngles;
		direction.transform.LookAt(currentPoint.GetComponent<WaypointController>().getNextPoint().transform);
		//Rotation vector to help keep ships upright
		Vector3 newRotation;

		//Find the angle the ship is going and where it wants to go relative to eachother
		float y1 = transform.eulerAngles.y;
		float y2 = direction.transform.eulerAngles.y;
		y2 -= 90 * (int)(y1 / 90);
		y1 -= 90 * (int)(y1 / 90);
		if (y2 < 0)
			y2 += 360;

		//Is the ship hovering close enough to the ground?
		if (Physics.Raycast (transform.position, - this.transform.up, 4.0f)) {
			rb.drag = 1;
			//If turn goal is within threshold, the speed up.
			iAccelDir = Mathf.Abs (y2 - y1) <= 45 ? 1 : 0;
			//Add force if ship is within threshold
			rb.AddForce (transform.forward * maxVelocity * 50.0f * iAccelDir * Time.deltaTime * rb.mass);
		} 
		//Ship to far from ground, turn drag off and right the ship
		else {
			rb.drag = 0;
			newRotation = transform.eulerAngles;
			newRotation.x = Mathf.SmoothDampAngle(newRotation.x, 0.0f, ref rotationVelocity, 0.25f);
			newRotation.z = Mathf.SmoothDampAngle(newRotation.z, 0.0f, ref rotationVelocity, 0.25f);
			transform.eulerAngles = newRotation;
		}	

		//Turn towards target
		iAccelDir = y2 < y1 + 180.0f && y2 > y1 ? 1 : -1;
		//Rotate character up to turnspeed
		rb.AddTorque (transform.up * fTurnSpeed * iAccelDir * Time.deltaTime * rb.mass);
	}

	public void nextPoint(){
		//If we hit the finish line, increment laps and such
		if (currentPoint.GetComponent<WaypointController> ().getNextPoint ().Equals (trackWaypoints.transform.GetChild (0).GetComponent<WaypointController> ().getPoint ())) {
			lap ++;
			if(lap >= 2)
				canMove = false;
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
		if (other.tag == "Waypoint" && other.gameObject.Equals(currentPoint.GetComponent<WaypointController> ().getNextPoint ())) {
			nextPoint ();
		}
	}
}
