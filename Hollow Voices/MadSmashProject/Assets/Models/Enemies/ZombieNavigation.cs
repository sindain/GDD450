using UnityEngine;
using System.Collections;

public class ZombieNavigation : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject player;
    public GameObject patrolDestination;
    public GameObject[] patrolPoints;
    int patrolNumber;
    bool canPatrol;
    bool aggro;
    public float attackRange;
    bool attack;
    Animator anim;
    public float damping;
    bool hunting;
    float time;
    bool timeStart;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        aggro = false;
        anim = GetComponent<Animator>();
        patrolPoints= GameObject.FindGameObjectsWithTag("patrol");
        patrolNumber = Random.Range(0, patrolPoints.Length);
        hunting = false;
        time = 0.0f;
        timeStart = false;

    }
    // Update is called once per frame
    void Update()
    {
       
        if (aggro)
        {
            if (hunting == false)
            {
                lookAtPlayer();
                patrolNumber = Random.Range(0, patrolPoints.Length);
                agent.ResetPath();
                anim.SetFloat("aggro", .0f);

            }
            else if(hunting)
            { 
                huntPlayer();
            }

        }
        else
        {
            patrol();     
        }
        time = Time.deltaTime + time;
      

    }
    void checkAttack()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < attackRange)
        {
            attack = true;
            anim.SetBool("canAttack", true);
        }
        else
        {
            attack = false;
            anim.SetBool("canAttack", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && aggro == false)
        {
            player = other.gameObject;
            aggro = true;
        }
       
    }
    void patrol()
    {
        agent.speed = .5f;
        aggro = false;
        hunting = false;
        anim.SetBool("canAttack", false);
        anim.SetFloat("aggro",.2f);
        agent.SetDestination(patrolPoints[patrolNumber].transform.position);
        float patDist = Vector3.Distance(patrolPoints[patrolNumber].transform.position, transform.position);
        if(patDist<1)
        {
            patrolNumber = Random.Range(0, patrolPoints.Length);
        }

    }

    void lookAtPlayer()
    {

            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
           if(timeStart==false)
            {
                resetTime();
            }
            if (Physics.Raycast(transform.position,fwd, out hit,10))
            {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                                hunting = true;
                                 print("im coming for that booty!");
                                 timeStart = false;         
                   }
            }
        if (time > 5.0f && timeStart == true)
        {
            patrol();
            print("lets go for a walk");
            timeStart = false;
        }
    }
    void resetTime()
    {
        time = 0;
        timeStart = true;
    }
    void huntPlayer()
    {
        checkAttack();
        anim.SetFloat("aggro", .3f);
        agent.SetDestination(player.transform.position);
        agent.speed = 5;
        if (timeStart == false)
        {
            resetTime();
        }
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
 
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                hunting = true;
                print("im coming for that booty!");
                timeStart = false;
            }
        }
        if (time > 5.0f && timeStart == true)
        {
            patrol();
            print("lets go for a walk");
            timeStart = false;
        }

    }


    }


