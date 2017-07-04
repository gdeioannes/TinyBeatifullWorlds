using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBehavior : MonoBehaviour,TouchObj {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction(){
		GenericTextMsg._instance.animateMsg("Tengo Hambre!!",gameObject);
	
	}
}
