﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInteraction : MonoBehaviour {

	public GameObject imageFade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.Log(ray.origin);
			Debug.DrawRay(ray.origin,Vector3.forward*100,Color.green,1);
			var hit = Physics2D.GetRayIntersection(ray);
			if (hit.collider != null) {

			Debug.Log("Collider "+hit.collider.gameObject.name);
			if(hit.collider.gameObject.name=="BotonComienzo"){				
					StartCoroutine(fadeTransition());
				}

			}
		}
	}

	IEnumerator fadeTransition(){
		StartCoroutine(Transitions._instance.fadeInImage(imageFade,0.05f));
		yield return new WaitForSeconds(2f);
		Application.LoadLevel (1);
	}
		
	public void backMenu(){
		Application.LoadLevel (0);
	}
}
