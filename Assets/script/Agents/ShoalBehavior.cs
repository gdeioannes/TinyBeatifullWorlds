using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoalBehavior : MonoBehaviour,TouchObj {

	public GameManager gameManager;
	public GameObject squid;
	public GameObject squidNewPostion;
	public GameObject squidOldPostion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction(){
		if(gameManager.stormLeaveFlag){
			gameManager.squidBusyFlag = true;
			StartCoroutine( Transitions._instance.animateObject(squid,squidNewPostion,20));
			StartCoroutine(squidReturn());
		}

		if(!gameManager.stormLeaveFlag){
			GenericTextMsg._instance.animateMsg("Un Cardumen!",gameObject);
		}
	}

	IEnumerator squidReturn(){
		yield return new WaitForSeconds (10);
		Debug.Log("Calamar Vuelve");
		gameManager.squidBusyFlag = false;
		StartCoroutine(Transitions._instance.animateObject(squid,squidOldPostion,20));
		//GenericTextMsg._instance.animateMsg("El calamar vuelve!!",gameObject);
	}
}



