using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour,TouchObj {

	public GameManager gameManager;
	public GameObject squid;
	public GameObject boatNewPostion;
	public GameObject boatDeadNewPostion;	
	private int maxTouch = 5;
	private int countTouch = 0;
	private bool toggleMsg=true;


	// Use this for initialization
	void Start () {
		squid.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction(){
		
		if (!gameManager.lightHouseOnFlag && !gameManager.animateFlag ){
			countTouch = countTouch + 1;
			GenericTextMsg._instance.animateMsg("No puedo ver la costa",gameObject);
		}else if(gameManager.lightHouseOnFlag && !gameManager.stormLeaveFlag){
			GenericTextMsg._instance.animateMsg("Costa a la vista, la tormenta es muy fuerte!!",gameObject);
		}

		if (!gameManager.lightHouseOnFlag && !gameManager.stormLeaveFlag) {
			switch(countTouch){
				
			case 1:gameManager.changeMessage ("El Barco no puede ver la costa...");
				break;

			case 2:gameManager.changeMessage ("Aun el Barco no puede ver la costa...");
				break;

			case 3:gameManager.changeMessage ("Sin la luz que guie su camino, no llegara a puerto.");
				break;


			}
		}
			
		if (!gameManager.stormLeaveFlag && checkMaxBoat ()) {
			gameManager.changeFinishMessage ("'Se nos debe liberar de la esperanza que el mar pueda reposar alguna vez. Debemos aprender a navergar con vientos fuertes' Aristoteles Onassis");
				gameObject.transform.position = boatDeadNewPostion.transform.position;
				gameManager.showPanel ();
				
		} else if (!gameManager.squidBusyFlag && gameManager.stormLeaveFlag) {
			StartCoroutine( gameManager.fadeInSprite (squid,0.01f));
				gameManager.changeMessage ("Y el bote fue detenido por el calamar");
			if(toggleMsg){
				GenericTextMsg._instance.animateMsg("Un Calamar Gigante!!",gameObject);
				toggleMsg=false;
			}else{
				GenericTextMsg._instance.animateMsg("Hay un Cardumen abajo!!",gameObject);
				toggleMsg=true;
			}
		} else if (gameManager.squidBusyFlag && gameManager.stormLeaveFlag && !gameManager.gameFinishFlag){
				gameManager.gameFinishFlag=true;
				GenericTextMsg._instance.animateMsg("Avancen camaradas!!",gameObject);
				gameManager.changeMessage ("El barco llego al puerto al fin");
				StartCoroutine (finishGameDemo());
			}



	}

	bool checkMaxBoat ()
	{
		return maxTouch - 1 == countTouch;
	}

	IEnumerator finishGameDemo(){
		while(Vector3.Distance(gameObject.transform.position,boatNewPostion.transform.position)>0.1f){
			gameObject.transform.position=Vector3.Lerp(gameObject.transform.position, boatNewPostion.transform.position,0.01f);
			yield return new WaitForSeconds (0.01f);
		}

		gameManager.changeFinishMessage ("Gracias por terminar la DEMO");
		gameManager.showPanel ();
		yield return null;
	}


}
