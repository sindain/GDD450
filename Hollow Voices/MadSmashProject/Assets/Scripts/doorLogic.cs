using UnityEngine;
using System.Collections;

public class doorLogic : MonoBehaviour {

    // Use this for initialization
    void Start () {
      
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.transform.Translate(Vector3.forward);
        }
    }
}

