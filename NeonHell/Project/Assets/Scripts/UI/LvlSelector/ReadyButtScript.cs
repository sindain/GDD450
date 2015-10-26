using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ReadyButtScript : MonoBehaviour {
	public static string lvlName="none";
	private bool isLvlSelected=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (lvlName != "none") 
		{
			isLvlSelected=true;
			gameObject.GetComponent<Button>().interactable=true;
		}
	
	}
	public void Transition(){
		if (isLvlSelected) {
			UIHandler.lose = false;
			Time.timeScale = 1;
			Application.LoadLevel (lvlName);
		}
	}
}
