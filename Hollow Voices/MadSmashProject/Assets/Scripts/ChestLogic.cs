using UnityEngine;
using System.Collections;

public class ChestLogic : MonoBehaviour {
    Animator anim;
    public GameObject coinPrefab;
    public GameObject ingot;
    public bool Looted = false;
    public bool canLoot = true;
    public Rigidbody rb;
    private Vector3 targetAngles;

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

        StartCoroutine(DoAnimation());
       
       
    }
    IEnumerator DoAnimation()
    {
        int randomNumber = Random.Range(1, 5);
        yield return new WaitForSeconds(2f); // wait for two seconds.
        for (int i = 0; i < randomNumber; i++)
        {
                 
           
            Instantiate(coinPrefab, transform.position, transform.rotation);
            rb = coinPrefab.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10);
        }


        if (randomNumber < 3)
        {
            Instantiate(ingot, transform.position, transform.rotation);
        }
    }  
  }


