using UnityEngine;
using System.Collections;

public class TempButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(15, 15, Screen.width / 10, Screen.height / 20), "Multiplayer Lobby"))
        {
            Application.LoadLevel("lobbyScene");
        }
    }
}
