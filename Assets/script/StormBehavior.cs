using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormBehavior : MonoBehaviour {

	public GameObject ligth;
	public ParticleSystem lighting;
	public ParticleSystem lightExplotion;
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		ligth.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void objectAction(){
		lightExplotion.Play ();
		lighting.Play ();
		if (gameManager.lightHouseOnFlag == false) {

			ligth.SetActive (true);
			gameManager.lightHouseOnFlag = true;
		} else {
			gameManager.lightHouseOnFlag = false;
			ligth.SetActive (false);
		}

		if (gameManager.lightHouseOnFlag == true) {
			gameManager.changeMessage ("La historia continua...");
		}else{ 
			gameManager.changeMessage ("El faro se apagó");
			
		}


	}
}
