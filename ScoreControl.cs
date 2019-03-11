using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {

	public GameObject Master;
	public int pointsFromMaster;
	public float time;

	public Text pointsText;
	public Text gameTime;
    public static int points;

	// Use this for initialization
	void Start () {
		pointsText.text = "Score: 0";
		Master = GameObject.Find("GameMaster");
		time = 60;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		pointsFromMaster = Master.GetComponent<WhackaMoleGM>().Points;
        points = pointsFromMaster;
		pointsText.text = "Score: " + pointsFromMaster.ToString();
		
		if (time >= 0)
		{
			time -= Time.deltaTime;
			gameTime.text = time.ToString("#");
			
		}
		if(time <= 0.5){
				gameTime.text = "0";
				Master.GetComponent<WhackaMoleGM>().TimeIsNowUp();
			}
		/*else{
			gameTime.text = "0";
		}*/
	}
    public int GivePoints()
    {
        return points;
    }
}
