using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelection : MonoBehaviour {

	public GameObject charnext, charcurrent;
	public int ActiveChar;

	// Use this for initialization
	void Start () {
		ActiveChar = 1;
		charcurrent = GameObject.Find("CharPreview" + ActiveChar);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Previous(){
		ActiveChar = ActiveChar - 1;
		if (ActiveChar <= 0)
		{
			ActiveChar = 4;
		}
		charnext = GameObject.Find("CharPreview" + ActiveChar);
		charnext.transform.position = new Vector3 (405.5f,286,0);
		charcurrent.transform.position = new Vector3(406,-200,0);
		charcurrent = charnext;

	}

	public void Next(){
		ActiveChar = ActiveChar + 1;
		if (ActiveChar >= 5)
		{
			ActiveChar = 1;
		}
		charnext = GameObject.Find("CharPreview" + ActiveChar);
		charnext.transform.position = new Vector3 (405.5f,286,0);
		charcurrent.transform.position = new Vector3(406,-200,0);
		charcurrent = charnext;
	}

}
