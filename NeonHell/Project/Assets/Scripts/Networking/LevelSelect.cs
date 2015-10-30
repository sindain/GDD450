using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LevelSelect : NetworkBehaviour {
    public bool levelSelector;
    public GameObject network;
	// Use this for initialization
    void Start()
    {
        levelSelector = true;
        print("onstart: " + levelSelector);
    }
    void OnStartHost()
    {
        levelSelector = true;
        print("onhost: " + levelSelector);
    }
	
	
	// Update is called once per frame
	void Update () {
	    	}
    void OnGUI(){
        if(levelSelector){

            if (GUI.Button(new Rect(Screen.width/1.5f, 15, Screen.width / 10, Screen.height / 20), "Game Track")){
                network.GetComponent<NetworkLobbyManager>().playScene = "Game";
            }
            if (GUI.Button(new Rect(Screen.width / 1.5f, 50, Screen.width / 10, Screen.height / 20), "Track 2")){
                network.GetComponent<NetworkLobbyManager>().playScene = "Track2";
            }        

        }

    }
}
