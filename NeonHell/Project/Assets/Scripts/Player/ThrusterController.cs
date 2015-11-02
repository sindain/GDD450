using UnityEngine;
using System.Collections;

public class ThrusterController : MonoBehaviour {
	public float thrustStrength;
	public float thrustDistance;
	public Transform[] thrusters;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		RaycastHit hit;
		foreach(Transform i in thrusters){
			Vector3 downardForce;
			float distancePercentage;

			if(Physics.Raycast (i.position, -i.up, out hit, thrustDistance)){
				if(hit.collider.isTrigger)return;
				distancePercentage = 1-(hit.distance/thrustDistance);
				downardForce = transform.up * thrustStrength * distancePercentage;
				downardForce = downardForce * Time.deltaTime * rb.mass;
				rb.AddForceAtPosition(downardForce, i.position);
			}//End if(Physics.Raycast (i.position, -i.up, out hit, thrustDistance)
		}
	}//End void FixedUpdate()
}
