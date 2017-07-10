using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageBehavior : MonoBehaviour {

	public GameObject ui;

	// Use this for initialization
	void Start () {
		ui.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime>1){
			ui.SetActive (true);
		}


	}
}
