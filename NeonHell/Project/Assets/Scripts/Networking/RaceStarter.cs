using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RaceStarter : MonoBehaviour {

    public Text start;
    public int timeStart;
    public float timer;
	// Use this for initialization
	void Start () {
        start.color = Color.red;
        start.text = "3";
        PlayerPrefs.SetFloat("start", 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        else{
            Destroy(start);
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
        
	}
}
//width 282.17
//height 180.2
//x 6
//y 15
//Z 0