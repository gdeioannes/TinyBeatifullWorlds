using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseBehavior : MonoBehaviour,TouchObj {

	public GameManager gameManager;
	public GameObject textElectricity;

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
			GenericTextMsg._instance.animateMsg("No hay electricidad!",gameObject);
		}else{
			GenericTextMsg._instance.animateMsg("Barco a la vista!",gameObject);
		}
		
	}

}
