using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour {
	public GameObject master;
	private Transform myTransform;
	private Color StartColor;
	public bool aboveGround;
	public bool activable;
	public bool TimeIsUp;

	public int MolePoint;
	public int Super;
	
	// Use this for initialization
	void Start () {
		StartColor = this.GetComponent<Renderer>().material.color;
		master = GameObject.Find("GameMaster");
		myTransform = this.transform;
		activable = true;
		MolePoint = 1;
		Super = 1;
		TimeIsUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(master.GetComponent<WhackaMoleGM>().TimeIsUp){
			TimeIsNowUp();
		}
	}
	void OnMouseDown(){
		if(!TimeIsUp){
			if(aboveGround){
				master.GetComponent<WhackaMoleGM>().AddPoints(MolePoint);
				submerge();
			}
		}

	}
	IEnumerator CoolDown(){
		yield return new WaitForSeconds(1);
		activable = true;
	}

	public void surface(){
		if(!aboveGround)
		{
		if(Super == Random.Range(1,11))
		{
			MolePoint = 10;
			this.GetComponent<Renderer>().material.color = Color.red;
		}
		myTransform.position = new Vector2(this.transform.position.x,this.transform.position.y + 1.2f);
		aboveGround = true;
		activable = false;
		}
	}
	public void submerge(){
		if (aboveGround)
		{
		myTransform.position = new Vector2(this.transform.position.x,this.transform.position.y - 1.2f);
		aboveGround = false;
		MolePoint = 1;
		this.GetComponent<Renderer>().material.color = StartColor;
		StartCoroutine(CoolDown());
		}
	}
	public void TimeIsNowUp(){
		TimeIsUp = true;
	}
}
