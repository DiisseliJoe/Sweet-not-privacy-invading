using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
	private bool Idaccepted;
	private bool IdNotaccepted;

	public Text InputFieldID;
	public GameObject okBtn;
	public GameObject PlayBtn;
	// Use this for initialization
	void Start () {
		Idaccepted = false;
		IdNotaccepted = false;
		PlayBtn.GetComponent<Image>().color = Color.grey;
	}
	
	// Update is called once per frame
	void Update () {
		if(Idaccepted == false && IdNotaccepted == false)
		{
			if (InputFieldID.text.Length >= 1)
			{
				okBtn.GetComponent<Image>().color = Color.white;
			}
			if(InputFieldID.text.Length <= 0)
			{
				okBtn.GetComponent<Image>().color = Color.grey;
			}
		}
		if (Idaccepted == true)
			{
				PlayBtn.GetComponent<Image>().color = Color.white;
			}

	}

	public void OkButton(){
		if(InputFieldID != null)
		{
			okBtn.GetComponent<Image>().color = Color.green;
			Idaccepted = true;
			IdNotaccepted = false;
		}
		if(InputFieldID == null)
		{
			okBtn.GetComponent<Image>().color = Color.red;
			Idaccepted = false;
			IdNotaccepted = true;
		}
	}
	public void PlayButton(){
		
	}
}
