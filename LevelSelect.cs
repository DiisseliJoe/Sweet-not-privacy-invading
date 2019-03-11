using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if(this.gameObject.name == "map1"){
			Application.LoadLevel("whackaMole");
		}
		if(this.gameObject.name == "map2"){
			Application.LoadLevel("EndlessRunner");
		}
		if(this.gameObject.name == "map3"){
			Application.LoadLevel("Flight");
		}
		if(this.gameObject.name == "play"){
			Application.LoadLevel("mapScreen");
		}
		if(this.gameObject.name == "exitToMain"){
			Application.LoadLevel("MainMenu");
		}
		if(this.gameObject.name == "exitToLevel"){
			Application.LoadLevel("mapScreen");
		}
		if(this.gameObject.name == "exitTheGame"){
			Application.Quit();
		}
		
	}
	public void ToMainMenu(){
		Application.LoadLevel("MainMenu");
	}
	public void ToLevelSelect(){
		Application.LoadLevel("mapScreen");
	}
	public void QuitGame(){
		Application.Quit();
	}
}


