using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	//public Transform spawnPoint;

	public GameObject item;
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;

	// Use this for initialization
	void Start () {
		int rand = Random.Range (0, 4);
		//Debug.Log (rand);

		if (rand == 0) {
			Instantiate (item, transform.position, transform.rotation);
		} else if (rand == 1) {
			Instantiate (item1, transform.position, transform.rotation);
		} else if (rand == 2) {
			Instantiate (item2, transform.position, transform.rotation);
		} else if (rand == 3) {
			Instantiate (item3, transform.position, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
