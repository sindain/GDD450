using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float vSpeed;
	
	private float nextFire;
	private float originalVSpeed;

	void Start(){
		originalVSpeed = vSpeed;
	}
	void Update (){
		if (Input.GetKey (KeyCode.LeftShift) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position-=transform.right*Time.deltaTime*speed;
			//transform.Rotate (new Vector3 (0, 0, -.5f));
			//transform.position-=transform.up*Time.deltaTime*speed*.25f;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position+=transform.right*Time.deltaTime*speed;
			//transform.Rotate (new Vector3 (0, 0, .5f));
			//transform.position-=transform.up*Time.deltaTime*speed*.25f;
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position+=transform.forward*Time.deltaTime*speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position-=transform.forward*Time.deltaTime*speed;
		}

		transform.position += transform.up*Time.deltaTime*vSpeed;
		if (vSpeed < -originalVSpeed) {
			vSpeed = -originalVSpeed;
		}
		if (vSpeed > originalVSpeed) {
			vSpeed = originalVSpeed;
		}

		if (transform.localPosition.x > -.2) {
			transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
		}
	}
	void FixedUpdate(){
		if (Input.GetKey ("space")) {
			GetComponent<Rigidbody>().AddForce (Vector3.up*5);
		}
	}
	/*public float GetVSpeed(){
		return vSpeed;
	}
	public void SetVSpeed(float newVSpeed){
		vSpeed = newVSpeed;
	}*/
}
