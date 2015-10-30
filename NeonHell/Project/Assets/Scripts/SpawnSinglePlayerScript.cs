using UnityEngine;
using System.Collections;

public class SpawnSinglePlayerScript : MonoBehaviour {
	public GameObject Player1;
	// Use this for initialization
	void Start () {
		Instantiate (Player1, gameObject.transform.position, gameObject.transform.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
