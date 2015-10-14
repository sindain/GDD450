using UnityEngine;
using System.Collections;

public class ActualPlayerScript : MonoBehaviour {

	public GameObject playerShadow;
	public UIHandler UIH;
	public GameObject canvas;
	public Rigidbody rb;
	public float sinWave;
	public float jumpArc;

	public bool jumping;
	private float timeKeeper;

	void Start (){
		canvas = GameObject.FindGameObjectWithTag ("UIH");
		UIH = canvas.GetComponent<UIHandler> ();
	}
	void Update(){

		transform.position = Vector3.MoveTowards (transform.position, playerShadow.transform.position, playerShadow.GetComponent<PlayerController> ().speed);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, playerShadow.transform.rotation, playerShadow.GetComponent<PlayerController> ().speed);
		if (!jumping) {	
			sinWave = Mathf.Sin ((Time.time-timeKeeper) * 2f) * .05f;
			transform.position += transform.up * sinWave;
		}
		if (jumping) {
			jumpArc = -2*(Time.time - timeKeeper-.5f)*(Time.time - timeKeeper-.5f)+.5f;
			transform.position += transform.up * jumpArc;
			if(Time.time - timeKeeper >= 1){
				jumping = false;
				timeKeeper = Time.time + Mathf.PI/2f;
			}
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(!jumping){
				jumping = true;
				timeKeeper = Time.time;
			}
		}

	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "laserTower") {
			print ("HIT");
			UIH.TakeDamage (1);
		}
	}
}
