using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour {

	private float saveFieldOfView;
	private float fov=10;

	// Use this for initialization
	void Start () {
		saveFieldOfView=Camera.main.fieldOfView;
		StartCoroutine(zoomLoop());

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
	}

	IEnumerator zoomLoop(){
		while(true){
			
			if(Input.GetAxis("Mouse ScrollWheel")>0){
				fov-=10;
			}

			if(Input.GetAxis("Mouse ScrollWheel")<0){
				fov+=10;
			}

			if(Input.GetAxis("Mouse ScrollWheel")==0){
				fov=Mathf.Lerp(0,fov,0.0001f);;
			}


			yield return new WaitForSeconds(1f);
		}
	}
}
