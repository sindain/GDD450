using UnityEngine;
using System.Collections;

public class WallBehavior : MonoBehaviour {

	public GameObject player;
	private bool upOrDown = true;
	private float originPos;

	void Start () {
		StartCoroutine (movingYo());
		originPos = transform.position.y;
	}

	IEnumerator movingYo(){
		while (true) {
			if(upOrDown == true){
				transform.position += Vector3.up*.02f;
				yield return new WaitForSeconds (.01f);
				if(transform.position.y > originPos){
					yield return new WaitForSeconds (2f);
					upOrDown = false;
				}
			}
			if(upOrDown == false){
				transform.position -= Vector3.up*.02f;
				yield return new WaitForSeconds (.01f);
				if(transform.position.y < originPos-.68){
					yield return new WaitForSeconds (1f);
					upOrDown = true;
				}
			}
		}
	}
}
