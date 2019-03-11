using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhackaMoleGM : MonoBehaviour {
	public GameObject controlledMole;
	public string pointtexts;

	private float moleNumber, lastNumber;
	
	public bool moleSurfaced;
	public bool StartWhacking;
	public bool TimeIsUp;

	public int Points;

	// Use this for initialization
	void Start () {
		moleSurfaced = false;
		StartWhacking = true;
		TimeIsUp = false;
		Points = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (!moleSurfaced)
		{
			callMole();
		}*/
		//Debug.Log(Points);
		if(!TimeIsUp){
			if(StartWhacking){
				StartWhacking = false;
				StartCoroutine(NextMole());
			}
		
		}
	}
	void callMole(){
		moleSurfaced = true;
			do
			{
			moleNumber = Random.Range(1,6);
			} while (moleNumber == lastNumber);
			lastNumber = moleNumber;
			
			controlledMole = GameObject.Find("mole"+moleNumber);
			if(controlledMole.GetComponent<MoleController>().activable)
			{
			controlledMole.GetComponent<MoleController>().surface();
			StartCoroutine(Wait(controlledMole));
			}
					
	}
	 public void AddPoints(int points){
		Points = Points + points;
	}
	

	IEnumerator Wait(GameObject oldMole){
		yield return new WaitForSeconds(3);
		moleSurfaced = false;
		Debug.Log("done");
		if(!TimeIsUp){
		oldMole.GetComponent<MoleController>().submerge();
		}
	}
	IEnumerator NextMole(){
		
		yield return new WaitForSeconds(Random.Range(1,3));	
		StartWhacking = true;
		callMole();
	}
	public void TimeIsNowUp(){
		TimeIsUp = true;
        SceneManager.LoadScene("whackVictory");
    }
	
}
