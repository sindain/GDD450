using UnityEngine;
using System.Collections;

public class lootScriptGold : MonoBehaviour {
    // intializes the score and then sets up the script variables to be called so we can change them to call animations.
    public int score;
  public GameObject chest;
    private ChestLogic chestlogic;
    public GameObject door;
    private DoorWayScript doorwayscript;

    // Use this for initialization
    void Start ()
    {
        
      
   
      

    }

    // Update is called once per frame
    void Update()
    {
        // intialises the hit raycast and hit. it creates ray and users mouse input to ray cast.
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // if the mouse is down it will check for a collider of the object and then from the collider pull the game object and the tag then adds points based on tag and destroys object.
            if (Input.GetMouseButtonDown(0))
            {
                
                    if(hit.collider.gameObject.tag=="goldCoin")
                    {
                        score++;
						GameObject.FindWithTag("HUD").GetComponent<HudScript>().addScore(1);
                        Destroy(hit.collider.gameObject);
                        print(score);
                    }
                    else if (hit.collider.gameObject.tag == "ingot")
                    {
                        score = score + 5;
						GameObject.FindWithTag("HUD").GetComponent<HudScript>().addScore(5);
                        Destroy(hit.collider.gameObject);
                        print(score);
                    }
                // if the collider is tied to safe tagged game object it will change the bool "Looted" in "ChestLogic>" script to true to open the safe
                else if (hit.collider.gameObject.tag == "Safe")
                    {
                         chest=hit.collider.gameObject;
                        chestlogic = chest.GetComponent<ChestLogic>();
                        chestlogic.Looted = true;
                    }

                }
            // if the collider is tied to a door tagged  game object it will change the "closed" bool in the "DoorWayScript" to false
            else if (hit.collider.gameObject.tag == "door")
                {
                    door = hit.collider.gameObject;
                    doorwayscript = door.GetComponent<DoorWayScript>();
                   doorwayscript.closed = false;
                    
                }
            }       
        }
    }

