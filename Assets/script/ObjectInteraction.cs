using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour {

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
				if(hit.collider.gameObject.GetComponent<TouchObj>() is TouchObj){				
					hit.collider.gameObject.GetComponent<TouchObj> ().objectInteraction ();
				}
			}
		}  
	}
}