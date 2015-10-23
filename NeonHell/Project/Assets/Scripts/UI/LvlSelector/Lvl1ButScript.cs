using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Lvl1ButScript : MonoBehaviour {
	public GameObject Map;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Clicked()
	{
		LvlDisplay.Old = LvlDisplay.New;
		LvlDisplay.New = Map;
		LvlDisplay.New.SetActive (true);
		if (LvlDisplay.Old != null) 
		{
			if(LvlDisplay.Old!=LvlDisplay.New)
			{
				LvlDisplay.Old.SetActive (false);
			}
		}
		ReadyButtScript.lvlName="Main";
	}
}
