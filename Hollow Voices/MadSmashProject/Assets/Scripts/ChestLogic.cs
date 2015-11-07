using UnityEngine;
using System.Collections;

public class ChestLogic : MonoBehaviour {
    Animator anim;
    public GameObject coinPrefab;
    public GameObject ingot;
    public bool Looted = false;
    public bool canLoot = true;
    float v;
    float h;
    float x;
    float y;
    float z;
    
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canLoot)
        {
            if (Looted == true)
            {
                anim.SetBool("open", Looted);
                spawnLoot();
                canLoot = false;
            }

        }
    }       
    void spawnLoot()
    {
        
       
           int randomNumber= Random.Range(1, 5);
        for (int i = 0; i < 4; i++)
        {
            
            Instantiate(coinPrefab, transform.position, transform.rotation);
           
        }
        if(randomNumber<3)
        {
            Instantiate(ingot, transform.position, transform.rotation);
        }
    }
}
