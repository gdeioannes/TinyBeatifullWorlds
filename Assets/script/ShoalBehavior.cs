using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoalBehavior : MonoBehaviour {

	public GameManager gameManager;
	public GameObject squid;
	public GameObject squidNewPostion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectAction(){
		gameManager.squidBusyFlag = true;
		gameManager.changeMessage ("El calamar llena su barriga");
		squid.SetActive (true);
		squid.transform.position=squidNewPostion.transform.position;
	}
}



