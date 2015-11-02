using UnityEngine;
using System.Collections;

public class RaceFinishButton : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Transition()
    {
        Application.LoadLevel("Title");
        Time.timeScale = 1;
    }
}
