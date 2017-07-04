using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoalBehavior : MonoBehaviour,TouchObj {

	public GameManager gameManager;
	public GameObject squid;
	public GameObject squidNewPostion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction(){
		if(gameManager.stormLeaveFlag){
			gameManager.squidBusyFlag = true;
			gameManager.changeMessage ("El calamar llena su barriga");
			squid.SetActive (true);
			StartCoroutine( gameManager.animateObject(squid,squidNewPostion));
		}
	}
}



