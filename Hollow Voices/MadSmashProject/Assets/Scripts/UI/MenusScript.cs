using UnityEngine;
using System.Collections;

public class MenusScript : MonoBehaviour {
	public GameObject titleMenu;
	public GameObject creditsMenu;
	public GameObject controlsMenu;
	
	public void onStartClicked()
	{
		Application.LoadLevel("LevelDesign1");
	}
	public void onControlsClicked()
	{
		titleMenu.SetActive (false);
		controlsMenu.SetActive (true);
	}
	public void onCreditsClicked()
	{
		titleMenu.SetActive (false);
		creditsMenu.SetActive (true);
	}
	public void onExitClicked()
	{
		Application.Quit ();
	}
	public void onBackClicked()
	{
		creditsMenu.SetActive (false);
		controlsMenu.SetActive (false);
		titleMenu.SetActive (true);
	}
}
