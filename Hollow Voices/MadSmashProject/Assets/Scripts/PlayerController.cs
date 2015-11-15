using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject Head;
	public GameObject Sphere;
	public float fMovementSpeed;
	public float sensitivityX = 1f;
	public float sensitivityY = 1f; 

	private Vector3 vRotation; //Keeps track of all player rotations
	private Transform camera;
	// Use this for initialization
	void Start () {
		camera = transform.FindChild ("Camera");
		vRotation = new Vector3(transform.localEulerAngles.x,
								transform.localEulerAngles.y,
								transform.localEulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		//Update Player position and rotation
		float moveH = Input.GetAxis ("Horizontal") * fMovementSpeed * Time.deltaTime;
		float moveV = Input.GetAxis ("Vertical") * fMovementSpeed * Time.deltaTime;
		transform.Translate (moveH, 0, moveV);
		
		//Rotations
		vRotation.y = vRotation.y + Input.GetAxis("Mouse X") * sensitivityX;
		vRotation.x = Mathf.Clamp(vRotation.x + Input.GetAxis("Mouse Y") * sensitivityY, -60.0f,60.0f);
		transform.localEulerAngles = new Vector3(0,vRotation.y,0f);
		camera.localEulerAngles = new Vector3 (-vRotation.x, 0, 0);
		//GameObject.Find("EthanHead").transform.localEulerAngles = new Vector3(0f,0f,-vRotation.x);
	}
}
