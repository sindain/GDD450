using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class RaceStarter : NetworkBehaviour {
    public GameObject player;
    public Text start;
	public Text laps;
    public Image menu;
    public int timeStart;
    public float timer;
    private bool finished;
    private int placed;
    public GameObject placeCounter;

    public int place;
	// Use this for initialization
	void Start () {
        placed = 0;
        place = 0;
        placeCounter = GameObject.FindWithTag("placeCounter");
        //PlayerPrefs.SetInt("place", 0);
        player.GetComponent<PlayerController1>().setLap(0);
        finished = false;
        start.color = Color.red;
        start.text = "3";
        PlayerPrefs.SetFloat("start", 0);
        menu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = !menu.enabled;
        }
        print("Placed: " + placed);
        print("Place Counter: " + placeCounter.GetComponent<PlaceCounter>().placeCounter);
        print("indi place: " + place);
        if (finished == false && player.GetComponent<PlayerController1>().getLap() >= 2)
        {
            placeCounter.GetComponent<PlaceCounter>().placeCounter = placeCounter.GetComponent<PlaceCounter>().placeCounter + 1;
            finished = true;
        }
        place = placeCounter.GetComponent<PlaceCounter>().placeCounter;
        if (player.GetComponent<PlayerController1>().canMove || PlayerPrefs.GetFloat("multi") == 0)
        {

            laps.text = "Laps: " + player.GetComponent<PlayerController1>().getLap() + "/2";
            if (timer < 5)
            {
                timer += Time.deltaTime;
            }
            else
            {
                if (placed == 0)
                {
                    start.enabled = false;
                }
            }
            if (timer >= 1 && timer < 5)
            {
                start.color = new Color(255, 165, 0);
                start.text = "2";
            }
            if (timer >= 2 && timer < 5)
            {
                start.color = Color.yellow;
                start.text = "1";
            }
            if (timer >= 3 && timer < 5)
            {
                start.color = Color.green;
                start.text = "GO!";
                PlayerPrefs.SetFloat("start", 1);
            }
            if (player.GetComponent<PlayerController1>().getLap() >= 2)
            {
                if (place == 1 && placed == 0)
                {
                    placed = 1;
                    start.enabled = true;
                    start.color = Color.green;
                    start.text = "1st Place :)";
                }
                if (place == 2 && placed == 0)
                {
                    placed = 1;
                    start.enabled = true;
                    start.color = Color.yellow;
                    start.text = "2nd Place :/";
                }
                if (place == 3 && placed == 0)
                {
                    placed = 1;
                    start.enabled = true;
                    start.color = new Color(255, 165, 0);
                    start.text = "3rd Place :|";
                }
                if (place == 4 && placed == 0)
                {
                    placed = 1;
                    start.enabled = true;
                    start.color = Color.red;
                    start.text = "4th Place :(";
                }

                menu.enabled = true;
                //end the race somehow
            }
        }
        else
        {
            menu.enabled = false;
            start.enabled = false;
            laps.enabled = false;
        }
        
	}
}
//width 282.17
//height 180.2
//x 6
//y 15
//Z 0