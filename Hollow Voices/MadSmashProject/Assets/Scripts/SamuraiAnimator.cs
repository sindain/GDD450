using UnityEngine;
using System.Collections;

public class SamuraiAnimator : MonoBehaviour {
    Animator anim;
    float h;
    float v;
    float run;
    float jump;
    public int bank;


    // Use this for initialization
    void Start ()
    {

        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {


        Walking();
        Sprinting();
        Jumping();
	
	}
    void FixedUpdate()
    {
        anim.SetFloat("Walk",v);
        anim.SetFloat("Turn", h);
        anim.SetFloat("Run", run);
        anim.SetFloat("Jump", jump);

    }
    public void Sprinting()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = 0.2f;


        }
       else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = 0.0f;
        }

    }
    public void Walking()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            v = 0.2f;

        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            v = 0.0f;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            v = -.2f;
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            v = 0.0f;
        }
    }
    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = 0.2f;

        }
        else jump = 0.0f;

    }
  public int GetBank()
    {
        return bank;
    }
    public void setBank(int g)
    {
        bank = g;
    }

public void showBank()
    {
        print(bank);
    }

}
