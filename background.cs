using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {
	public Sprite Space_background;
	private Sprite start_background;
	private bool firstSwap;
    public FlightScore ScoreController;
    // Use this for initialization
    void Start () {
		firstSwap = false;
		start_background = this.GetComponent<SpriteRenderer>().sprite;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ScoreController.timeIsUp)
        {
            checkPosition();
            descent();
        }
    }

	void checkPosition(){                   // Moves lowest background image to top and if its first time swap to
                                            //current sprite then it changes sprite to "Space" background sprite
		if(this.transform.position.y <= -15){
			this.transform.position = new Vector2(this.transform.position.x,27.94f);
			if(!firstSwap){
				this.GetComponent<SpriteRenderer>().sprite = Space_background;
				firstSwap = true;
			}
		}
	}
	void descent(){             //Moves background image down
		this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y-0.1f);
	}
}
