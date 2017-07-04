using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapBehavior : MonoBehaviour,TouchObj {

	public GameManager gameManager;
	public GameObject storm;
	public GameObject shoal;
	public GameObject scene_2;
	public GameObject waterStorm;
	public GameObject fog_1;
	public GameObject fog_2;
	private int maxTouch = 4;
	private int countTouch = 0;
	private int rotationCap = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction (){

		if (checkMaxCap ()) {
			
			gameManager.stormLeaveFlag = true;

			StartCoroutine( gameManager.fadeOutSprite (storm,0.1f));
			if (gameManager.lightHouseOnFlag == false) {
				gameManager.changeMessage ("La Historia termina abruptamente.");
				gameManager.showPanel ();
			} else {
				gameManager.changeMessage ("Y las historia continua");
				scene_2.gameObject.SetActive (true);
				StartCoroutine( gameManager.fadeOutSprite (waterStorm,0.1f));
				StartCoroutine( gameManager.fadeOutSprite (fog_1,0.3f));
				StartCoroutine( gameManager.fadeOutSprite (fog_2,0.4f));
				gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
				gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, Random.Range(200f,350f)));
				Vector3 newPos=gameObject.transform.position;
				gameObject.transform.position=new Vector3(newPos.x,newPos.y,newPos.z-0.5f);

			}
		} else {
			rotationCap *= -1;
			gameObject.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+(0.05f+(Random.Range(0.4f,0.10f))),gameObject.transform.position.z);
			gameObject.transform.eulerAngles =new Vector3(0,0,(Random.Range(15f,25f)*rotationCap));
			countTouch = countTouch + 1;
			if (gameManager.lightHouseOnFlag) {
				gameManager.changeMessage ("Sigue");
			} else { 
				gameManager.changeMessage ("Enciende la luz");
			}

		}


	}

	bool checkMaxCap ()
	{
		return maxTouch - 1 == countTouch;
	}
}

