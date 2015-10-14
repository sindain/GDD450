using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject shot;
	public GameObject LeftWing;
	public GameObject RightWing;
	public Transform shotSpawn;
	public float fireRate;
	public GameObject player;
	public GameObject frontOfShip;
	public GameObject backOfShip;
	public UIHandler UIH;
	public GameObject canvas;

	
	private float nextFire;
	private bool goingLeft;
	private bool canGoLeft;
	private bool canGoRight;
	private bool canGoForward;
	private bool canGoBackwards;

	private bool keyUpDown;
	private bool keyDownDown;
	private bool keyLeftDown;
	private bool keyRightDown;
	private bool keyAnyShootDown;



	void Update (){
		RaycastHit leftHit;
		RaycastHit rightHit;
		canGoLeft = true;
		canGoRight = true;
		canGoForward = true;
		canGoBackwards = true;
		RaycastHit[] hits;
		hits = Physics.RaycastAll (LeftWing.transform.position,-LeftWing.transform.up,.35f);
		for(int i = 0;i<hits.Length;i++){
			RaycastHit hit = hits[i];
			if(hit.transform.GetComponent<Collider>().tag == "Bounding"){
				canGoLeft = false;
			}
		}
		hits = Physics.RaycastAll (RightWing.transform.position,-RightWing.transform.up,.35f);
		for(int i = 0;i<hits.Length;i++){
			RaycastHit hit = hits[i];
			if(hit.transform.GetComponent<Collider>().tag == "Bounding"){
				canGoRight = false;
			}
		}
		hits = Physics.RaycastAll (frontOfShip.transform.position,-frontOfShip.transform.up,.45f);
		for(int i = 0;i<hits.Length;i++){
			RaycastHit hit = hits[i];
			if(hit.transform.GetComponent<Collider>().tag == "Bounding"){
				canGoForward = false;
			}
		}
		hits = Physics.RaycastAll (backOfShip.transform.position,-backOfShip.transform.up,.45f);
		for(int i = 0;i<hits.Length;i++){
			RaycastHit hit = hits[i];
			if(hit.transform.GetComponent<Collider>().tag == "Bounding"){
				canGoBackwards = false;
			}
		}




		if (Input.GetKey (KeyCode.A)) {
			if(canGoLeft){
				transform.position-=transform.right*Time.deltaTime*speed;
				goingLeft = true;
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if(canGoRight){
				transform.position+=transform.right*Time.deltaTime*speed;
				goingLeft = false;
			}
		}
		if (Input.GetKey (KeyCode.W) && canGoForward) {
			transform.parent = GameObject.FindWithTag ("FasterForward").transform;
		} else if (Input.GetKey (KeyCode.S) && canGoBackwards) {
			transform.parent = GameObject.FindWithTag ("SlowerForward").transform;
		}else {
			transform.parent = GameObject.FindWithTag ("GameController").transform;
		}


		keyAnyShootDown = false;
		if (Input.GetKey (KeyCode.UpArrow)) {
			keyUpDown = true;
			keyAnyShootDown = true;
		} else {
			keyUpDown = false;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			keyDownDown = true;
			keyAnyShootDown = true;
		} else {
			keyDownDown = false;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			keyLeftDown = true;
			keyAnyShootDown = true;
		} else {
			keyLeftDown = false;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			keyRightDown = true;
			keyAnyShootDown = true;
		} else {
			keyRightDown = false;
		}

		if (Time.time > nextFire) {
			if(keyLeftDown){
				nextFire = Time.time + fireRate;
				shotSpawn.localRotation = Quaternion.Euler (0, -40, 0);
			}
			if(keyRightDown){
				nextFire = Time.time + fireRate;
				shotSpawn.localRotation = Quaternion.Euler (0, 40, 0);
			}
			if (keyUpDown) {
				nextFire = Time.time + fireRate;
				if (keyRightDown) {
					shotSpawn.localRotation = Quaternion.Euler (0, 20, 0);
				} else if(keyLeftDown){
					shotSpawn.localRotation = Quaternion.Euler (0, -20, 0);
				}else{
					shotSpawn.localRotation = Quaternion.Euler (0, 0, 0);
				}
			}
			if(keyAnyShootDown){
				Instantiate (shot, shotSpawn.position, shotSpawn.localRotation);
			}
		}

		//Debug.DrawRay (transform.position, -transform.up,Color.white, 0f, true);

		Debug.DrawRay (RightWing.transform.position, -RightWing.transform.up,Color.white, 0f, true);
		Debug.DrawRay (LeftWing.transform.position, -LeftWing.transform.up,Color.white, 0f, true);
		Debug.DrawRay (frontOfShip.transform.position, -frontOfShip.transform.up,Color.white, 0f, true);
		Debug.DrawRay (backOfShip.transform.position, -backOfShip.transform.up,Color.white, 0f, true);

		while(Physics.Raycast (LeftWing.transform.position, -LeftWing.transform.up, out leftHit,0.35f)){
			if(leftHit.collider.tag == "Arena" && goingLeft)
				transform.Rotate (new Vector3 (0, 0, -.05f));
			else break;
		}
		while(Physics.Raycast (RightWing.transform.position, -RightWing.transform.up,out rightHit,0.35f)){
			if(rightHit.collider.tag == "Arena" && !goingLeft)
				transform.Rotate (new Vector3 (0, 0, .05f));
			else break;
		}
		if(Physics.Raycast (LeftWing.transform.position, -LeftWing.transform.up, out leftHit,0.35f)){
			if(Physics.Raycast (RightWing.transform.position, -RightWing.transform.up,out rightHit,0.35f)){
				if (leftHit.distance < rightHit.distance) {
					transform.Rotate (new Vector3 (0, 0, -.05f));
				}
				if (leftHit.distance > rightHit.distance) {
					transform.Rotate (new Vector3 (0, 0, .05f));
				}
			}
		}
	}

}
