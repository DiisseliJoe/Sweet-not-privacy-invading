using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlightScore : MonoBehaviour {

	public Text scoreText;
    public Text TimeText;
	public static int points;

    public bool timeIsUp;
	

    public float time;
	// Use this for initialization                        
	void Start () {
        time = 60;
        timeIsUp = false;
		points = 0;
	}
	
	// Update is called once per frame
	void Update () {
			scoreText.text = "Score: " + points;
	
	}
    private void FixedUpdate()
    {
        if (!timeIsUp)
        {
            points += 1;
            if (time >= 0)
            {
                time -= Time.deltaTime;
                TimeText.text = time.ToString("#");
            }
            if (time <= 0.5)
            {
                TimeText.text = "0";
                timeIsUp = true;
            }

            if (time > 30)
            {
                TimeText.color = Color.green;
            }
            if (time <= 30 && time >= 10)
            {
                TimeText.color = Color.yellow;
            }
            if (time < 10)
            {
                TimeText.color = Color.red;
            }
        }
        if (timeIsUp)
        {
            SceneManager.LoadScene("VictoryScreen");
        }
    }
    public void PlusTime(){             //adds play time if player hits a ring
		time += 1.5f;
		
	}
	public void MinusTime(){            //removes play time if player hits a rock
		time -= 5f;
		
	}
    public int GivePoints()
    {
        return points;
    }
}
