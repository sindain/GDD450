using UnityEngine;
using System.Collections;

public class NPCNavController : MonoBehaviour {
	public GameObject TrackWaypoints;

	private Transform target;
	private NavMeshAgent navAgent;
	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		target = TrackWaypoints.transform.GetChild (0).GetComponent<WaypointController> ().getPoint ().transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
			navAgent.SetDestination (target.transform.position);
	}

	void onTriggerEnter(Collider other){
		if (other.tag == "Waypoint")
			target = target.GetComponent<WaypointController> ().getNextPoint ().transform;
	}
}
