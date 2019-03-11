using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleControl : MonoBehaviour {
	private float SpotX, SpotY, extra;
	public FlightScore ScoreController;
	// Use this for initialization
	void Start () {
		SpotY = 25f;
		extra = 20f;
        relocate();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!ScoreController.timeIsUp)
        {
            descent();                                  //If object falls below camera it moves it back to top 
            if (this.transform.position.y <= -15f)
            {
                relocateExtra();
            }
        }
	}
	void descent(){
		this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y-0.07f);
	}
	void relocate(){
		SpotX = Random.Range(-7f,7f);
		this.transform.position = new Vector2(SpotX,this.transform.position.y + SpotY);
	}void relocateExtra(){
		SpotX = Random.Range(-7f,7f);
		this.transform.position = new Vector2(SpotX,this.transform.position.y + SpotY + extra);
	}
	void OnCollisionEnter2D(Collision2D obstacle){ // Moves Rings and rocks to new random spot if they collide with something else expect player model
		if(obstacle.gameObject.tag == "Ring"){
			this.transform.position = new Vector2(this.transform.position.x + (Random.Range(-1,2)),this.transform.position.y);
		}
		if(obstacle.gameObject.tag == "Rock"){
			this.transform.position = new Vector2(this.transform.position.x + (Random.Range(-1,2)),this.transform.position.y);
		}
		if(obstacle.gameObject.tag == "Player"){
			relocate();
			if(this.gameObject.tag == "Ring"){
				ScoreController.PlusTime();
			}
			if(this.gameObject.tag == "Rock"){
				ScoreController.MinusTime();
			}
			
		}
	}
}

