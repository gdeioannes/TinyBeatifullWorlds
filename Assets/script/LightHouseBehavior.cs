using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseBehavior : MonoBehaviour,TouchObj {

	public GameManager gameManager;
	public GameObject textElectricity;
	public GameObject textBoat;

	// Use this for initialization
	void Start () {
		textElectricity.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction(){
		if (gameManager.lightHouseOnFlag == false) {
			Debug.Log ("LigthHouseBehavior");
			StartCoroutine(gameManager.animateAndHideObject (textElectricity, 1f));
		}
		
	}

}
