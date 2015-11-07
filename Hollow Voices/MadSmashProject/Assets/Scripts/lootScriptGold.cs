﻿using UnityEngine;
using System.Collections;

public class lootScriptGold : MonoBehaviour {
    public int score;
  public GameObject chest;
    private ChestLogic chestlogic;

    // Use this for initialization
    void Start ()
    {
        
      
   
      

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "Loot")
                {
                    if(hit.collider.gameObject.name=="goldCoin"|| hit.collider.gameObject.name == "goldCoin(Clone)")
                    {
                        score++;
                        Destroy(hit.collider.gameObject);
                        print(score);
                    }
                    else if (hit.collider.gameObject.name == "ingot" || hit.collider.gameObject.name == "ingot(Clone)")
                    {
                        score = score + 5;
                        Destroy(hit.collider.gameObject);
                        print(score);
                    }
                    else if (hit.collider.gameObject.name == "Safe")
                    {
                         chest=hit.collider.gameObject;
                        chestlogic = chest.GetComponent<ChestLogic>();
                        chestlogic.Looted = true;
                    }
                }
            }       
        }
    }
}
