using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VicScreen : MonoBehaviour {

    public FlightScore FlightScore;
    public Text pointsText;
    public float points;
    public string pointstring;
	// Use this for initialization
	void Start () {
        points = 0;
        points = GetComponent<FlightScore>().GivePoints();
        pointstring = points.ToString();
        pointsText.text = "Pisteesi: " + pointstring;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
