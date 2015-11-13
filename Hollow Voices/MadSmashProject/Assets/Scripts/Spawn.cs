using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public Transform spawnPoint;

	public GameObject item;
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;

	// Use this for initialization
	void Start () {
		int rand = Random.Range (0, 4);
		//Debug.Log (rand);

		if (rand == 0) {
			Instantiate (item, spawnPoint.position, spawnPoint.rotation);
			//Instantiate (item, new Vector3 (428, 508, -668), Quaternion.identity);
		} else if (rand == 1) {
			Instantiate (item1, spawnPoint.position, spawnPoint.rotation);
			//Instantiate (item1, new Vector3 (428, 508, -668), Quaternion.identity);
		} else if (rand == 2) {
			Instantiate (item2, spawnPoint.position, spawnPoint.rotation);
			//Instantiate (item2, new Vector3 (428, 508, -668), Quaternion.identity);
		} else if (rand == 3) {
			Instantiate (item3, spawnPoint.position, spawnPoint.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
