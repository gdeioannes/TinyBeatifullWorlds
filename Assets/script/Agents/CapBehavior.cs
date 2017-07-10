using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapBehavior : MonoBehaviour,TouchObj {

	public GameManager gameManager;
	public GameObject storm;
	public GameObject clouds;
	public GameObject shoal;
	public GameObject scene_2;
	public GameObject waterStorm;
	public GameObject fog_1;
	public GameObject fog_2;
	private int maxTouch = 3;
	private int countTouch = 0;
	private int rotationCap = 1;
	public GameObject particleContainer;

	// Use this for initialization
	void Start () {
		clouds.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction (){

		if (checkMaxCap ()) {
			
			gameManager.stormLeaveFlag = true;
			stopParticles();
			StartCoroutine( Transitions._instance.fadeOutSprite (storm,0.1f));
			StartCoroutine( Transitions._instance.fadeInSprite (clouds,0.5f));
			if (gameManager.lightHouseOnFlag == false) {
				GenericTextMsg._instance.animateMsg("La Historia termina en trajedia.",gameObject);
				GameManager._instance.gameFinishFlag=true;
				addPhysics ();
				StartCoroutine(looseGame());
			} else{
				gameManager.changeMessage ("Y las historia continua");
				scene_2.gameObject.SetActive (true);
				addPhysics ();
			}
		} else if(!Transitions._instance.animateFlag){
			countTouch++;	
			rotationCap *= -1;
			Vector3 newPos=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+(0.5f+(Random.Range(0.4f,0.10f))),gameObject.transform.position.z);
			
			StartCoroutine(Transitions._instance.animateObject(gameObject,newPos,20));

			if (gameManager.lightHouseOnFlag && !Transitions._instance.animateFlag) {
				gameManager.changeMessage ("Sigue");
				GenericTextMsg._instance.animateMsg("La tapa esta suelta",gameObject);
			} else if(!Transitions._instance.animateFlag){ 
				gameManager.changeMessage ("Enciende la luz");
				GenericTextMsg._instance.animateMsg("Espera a la calma",gameObject);
			}

		}


	}

	bool checkMaxCap ()
	{
		return maxTouch - 1 == countTouch;
	}

	void stopParticles(){
		foreach (Transform child in particleContainer.transform) {
			child.gameObject.GetComponent<ParticleSystem>().Stop();
		}
	}

	void addPhysics ()
	{
		StartCoroutine (Transitions._instance.fadeOutSprite (waterStorm, 0.1f));
		StartCoroutine (Transitions._instance.fadeOutSprite (fog_1, 0.3f));
		StartCoroutine (Transitions._instance.fadeOutSprite (fog_2, 0.4f));
		gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (-100f, 150f), Random.Range (200f, 350f)));
		gameObject.GetComponent<Rigidbody2D> ().AddTorque (Random.Range (-20f, 40f));
		Vector3 newPos = gameObject.transform.position;
		gameObject.transform.position = new Vector3 (newPos.x, newPos.y, newPos.z - 0.5f);
	}

	IEnumerator looseGame(){
		yield return new WaitForSeconds(2);
		gameManager.showPanel ();
	}
}

