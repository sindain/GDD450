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
	}
	
	// Update is called once per frame
	void Update () {
		lootCounter.text = "Loot: " + Score;
	}
	public void addScore(int amount)
	{
		Score = Score + amount;
	}
}
