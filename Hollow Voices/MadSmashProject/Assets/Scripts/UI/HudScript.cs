using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HudScript : MonoBehaviour {
	private int Score;
	public Text lootCounter;
	// Use this for initialization
	void Start () 
	{
		Score = 0;
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {

		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		lootCounter.text = "Loot: " + Score;


		if(Input.GetKeyUp(KeyCode.Alpha7))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().AddBoost("Boost1");
		}
		if(Input.GetKeyUp(KeyCode.Alpha8))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().AddBoost("Boost2");
		}
		if(Input.GetKeyUp(KeyCode.Alpha9))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().AddBoost("Boost3");
		}
		if(Input.GetKeyUp(KeyCode.Alpha0))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().AddBoost("None");
		}


	}
	public void addScore(int amount)
	{
		Score = Score + amount;
	}
	public void AddBoost(string BoostType)
	{
		if(BoostType == "Boost1")
		{
			gameObject.GetComponentInChildren<Image>().color = Color.red;
		}
		else if(BoostType == "Boost2")
		{
			gameObject.GetComponentInChildren<Image>().color = Color.green;
		}
		else if(BoostType == "Boost3")
		{
			gameObject.GetComponentInChildren<Image>().color = Color.yellow;
		}
		else if(BoostType == "None")
		{
			gameObject.GetComponentInChildren<Image>().color = Color.white;
		}
	}
}
