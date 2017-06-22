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
				Debug.Log("Collider "+hit.collider.gameObject.name);
				if(hit.collider.gameObject.name=="Cap"){				
					hit.collider.gameObject.GetComponent<CapBehavior> ().looseCap ();
				}
				if(hit.collider.gameObject.name=="Storm"){				
					hit.collider.gameObject.GetComponent<StormBehavior> ().objectAction ();
				}
				if(hit.collider.gameObject.name=="Boat"){				
					hit.collider.gameObject.GetComponent<BoatBehavior> ().objectAction ();
				}

				if(hit.collider.gameObject.name=="Shoal"){				
					hit.collider.gameObject.GetComponent<ShoalBehavior> ().objectAction ();
				}

				if(hit.collider.gameObject.name=="LightHouse"){				
					hit.collider.gameObject.GetComponent<LightHouseBehavior> ().lightHouseText ();
				}


			}
		}  
	}
}