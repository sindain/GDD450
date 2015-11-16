using UnityEngine;
using System.Collections;

public class MenusScript : MonoBehaviour {
	public GameObject titleMenu;
	public GameObject creditsMenu;
	public GameObject controlsMenu;
	
	public void onStartClicked()
	{
        Application.LoadLevel("MultiplayerLobby");
		//Application.LoadLevel("TestScene1");
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
    void OnGUI()
    {
        /*if (GUI.Button(new Rect(15, 15, Screen.width / 10, Screen.height / 20), "Multiplayer Lobby"))
        {
            Application.LoadLevel("MultiplayerLobby");
        }*/
    }
}
