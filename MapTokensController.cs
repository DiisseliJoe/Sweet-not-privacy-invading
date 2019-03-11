using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTokensController : MonoBehaviour {
	public bool change;
	public bool LevelCleared;
	public GameObject Selected;
	public Camera cam;

	public GameObject PlayButton;
	public GameObject Target;

	public int numberOfLevel;
	public int numberOfCleared;
	public int numOfSelec;
	public Vector2 origin; 

	//.......................................................

	public int CurrentLevel;
	public int i = 0;
	public float speed = 0.1f;

	public bool cleared = false;
	
	public GameObject MainCamera;

	private int SelectedLevel = 1;
	private GameObject Changeling;
	private string nameOfobj;
	private Vector3 dragOrigin;
	private Vector3 clickOrigin;
	private Vector3 basePos = Vector3.zero;

	//........................................................


	// Use this for initialization
	void Start () {
		if(numberOfLevel==null){
		numberOfLevel = 1;}
		if(numberOfCleared == null){
		numberOfCleared = 0;}
		change = false;
		MoveButton();
	//........................................................
		if(CurrentLevel == null){
			CurrentLevel = 0;}
		checkForChange();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)){
			Raycasting();
		}
		if (change == true){
			MoveButton();
		}
	//.......................................................
		CameraMovement();
		
	}

	void Raycasting(){ //Selects map to play but doesnt allow to select map if you havent finished one before it
		origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero);
		if(hit.collider != null){
			if (hit.collider.tag == "Map"){
				numOfSelec = int.Parse(hit.collider.name.Substring(hit.collider.name.Length - 1));
				Debug.Log(numOfSelec);
				if(numberOfCleared + 1 >= numOfSelec ){
				Selected = hit.collider.gameObject;
					if (numberOfLevel != int.Parse(Selected.name.Substring(Selected.name.Length - 1))){
						numberOfLevel = int.Parse(Selected.name.Substring(Selected.name.Length - 1));
						change = true;
					}
				}
			}
			if (hit.collider.gameObject.name == "playbutton"){
					string levelname = "map"+numberOfLevel;
					SceneManager.LoadScene(levelname);	
			}
			if (hit.collider.gameObject.name == "playbutton"){
					string levelname = "map"+numberOfLevel;
					SceneManager.LoadScene(levelname);	
			}
		}
	}
	
		
	void MoveButton(){ //moves "PLAY" button below the selected map token
			string targetName = "maptoken"+numberOfLevel;
			Target = GameObject.Find(targetName);
			PlayButton.transform.position = new Vector3(Target.transform.position.x,Target.transform.position.y-84f,Target.transform.position.z+1f);
			change = false;
	}

	void FinishedLevel(){
		LevelCleared = true;								
				numberOfCleared += 1;								
				if(numberOfCleared >= 7){							
					numberOfCleared = 6;							
				}													
				if(LevelCleared){		 //Moves automatically camera to next map token and selects it							
					CurrentLevel += 1;								
						checkForChange();								
					numberOfLevel += 1;						
						MoveButton();									
					LevelCleared = false;							
						MoveCamera();
				}
	}
	//........................................................................................................................................................
	void checkForChange(){                                  //Turns map roads to green towards the begining from current unfinished map
			for(i=1;i<=CurrentLevel; i++){
				nameOfobj = "maptoken" + i;
				Changeling = GameObject.Find(nameOfobj);
				Changeling.GetComponent<SpriteRenderer>().color = Color.green;

				nameOfobj = "road" + i;
				Changeling = GameObject.Find(nameOfobj);
				Changeling.GetComponent<SpriteRenderer>().color = Color.green;
			}
	}
	void CameraMovement(){
		if(Input.GetMouseButton(0)){
			if(clickOrigin == Vector3.zero){
				clickOrigin = Input.mousePosition;
				basePos = MainCamera.transform.position;
			}
			dragOrigin = Input.mousePosition;
		}
		if(!Input.GetMouseButton(0)){
			clickOrigin = Vector3.zero;
			return;
		}
		MainCamera.transform.position = new Vector3(Mathf.Clamp(basePos.x + ((clickOrigin.x - dragOrigin.x) * 0.6f), 0, 1500),MainCamera.transform.position.y,MainCamera.transform.position.z);
	}
	void MoveCamera(){
		MainCamera.transform.position = new Vector3(Target.transform.position.x,MainCamera.transform.position.y,MainCamera.transform.position.z);
	}
}
