using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour {
    // intializes the score and then sets up the script variables to be called so we can change them to call animations.
	public float fReachDistance = 2.0f;
	private GameObject cam;

    private ChestLogic chestlogic;
    private DoorWayScript doorwayscript;

    // Use this for initialization
    void Start ()
    {
		cam = transform.FindChild ("Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        // intialises the hit raycast and hit. it creates ray and users mouse input to ray cast.
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, fReachDistance))
		{	
			print(hit.collider.name);
            // if the mouse is down it will check for a collider of the object and then from the collider pull the game object and the tag then adds points based on tag and destroys object.
            if (Input.GetMouseButtonDown(0))
            {
				switch(hit.collider.gameObject.tag){
				case "goldCoin":
					collect(1,hit);
					break;
				case "ingot":
					collect(5,hit);
					break;
				case "Safe":
					// if the collider is tied to safe tagged game object it will change the bool "Looted" in "ChestLogic>" script to true to open the safe
					 hit.collider.gameObject.GetComponent<ChestLogic>().Looted = true;
					break;
				case"door":
						hit.collider.gameObject.GetComponent<DoorWayScript>().StartAnime();
					break;
				default:
					break;
				} //End switch(hit.collider.gameObject.tag)
            }
		} //End if (Physics.Raycast(ray, out hit))   
    }//End void Update()

	//TODO: enter function header
	//Collects the object and increments score.
	private void collect(int pPoints, RaycastHit pHit){
		GetComponent<CharacterStats> ().adjLoot (pPoints);
		GameObject.FindWithTag("HUD").GetComponent<HudScript>().addScore(pPoints);
		Destroy(pHit.collider.gameObject);
	} //End private void collect(int pPoints, RaycastHit pHit)
} //End public class lootScriptGold : MonoBehaviour

