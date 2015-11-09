using UnityEngine;
using System.Collections;

public class DoorWayScript : MonoBehaviour {
    Animator anim;
   public bool closed=true;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
   
            anim.SetBool("closed", closed);
       
	}
}
