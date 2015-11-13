using UnityEngine;
using System.Collections;

public class wallSpawn : MonoBehaviour {

	public Transform spawnPoint;

	public GameObject wallItem;
	public GameObject wallItem1;
	public GameObject wallItem2;

	// Use this for initialization
	void Start () {
		int rand = Random.Range (0, 3);
		Debug.Log (rand);

		if (rand == 0) {
			Instantiate (wallItem, spawnPoint.position, spawnPoint.rotation);
		} else if (rand == 1) {
			Instantiate (wallItem1, spawnPoint.position, spawnPoint.rotation);
		} else if (rand == 2) {
			Instantiate (wallItem2, spawnPoint.position, spawnPoint.rotation);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
