using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour,TouchObj {

	public static BoatBehavior _instance;
	public GameManager gameManager;
	public GameObject squid;
	public GameObject boatNewPostion;
	public GameObject boatDeadNewPosition;	
	private int maxTouch = 5;
	private int countTouch = 0;
	private bool toggleMsg=true;


	// Use this for initialization
	void Start () {
		squid.SetActive (false);
		if(_instance==null){
			_instance=this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void objectInteraction(){
		if(!GameManager._instance.gameFinishFlag){
			SoundManager._instance.playSeagull();
		}
		if (!gameManager.lightHouseOnFlag && !Transitions._instance.animateFlag){
			countTouch = countTouch + 1;
			if (!gameManager.lightHouseOnFlag && !gameManager.stormLeaveFlag) {
				switch(countTouch){

				case 1:GenericTextMsg._instance.animateMsg ("No podemos ver la costa",gameObject);
					break;

				case 2:GenericTextMsg._instance.animateMsg ("Aun no podemos ver la costa...",gameObject);
					break;

				case 3:GenericTextMsg._instance.animateMsg ("Sin luz No podemos ver la costa",gameObject);
					break;

				case 4:GenericTextMsg._instance.animateMsg ("La tormenta es muy fuerte!!",gameObject);
					break;

				}
			}
		}else if(gameManager.lightHouseOnFlag && !gameManager.stormLeaveFlag){
			GenericTextMsg._instance.animateMsg("Costa a la vista, la tormenta es muy fuerte!!",gameObject);
		}
			
		if (!gameManager.stormLeaveFlag && checkMaxBoat ()) {
				StartCoroutine(endLooseGame());
				
		} else if (!gameManager.squidBusyFlag && gameManager.stormLeaveFlag ) {
				if(!gameManager.squidApearFlag){
				StartCoroutine( Transitions._instance.fadeInSprite (squid,0.01f));
					gameManager.squidApearFlag=true;
				}
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

		GenericTextMsg._instance.animateMsgNoConditions("Llegamos Camaradas!!",gameObject);
		yield return new WaitForSeconds (3f);
		gameManager.changeFinishMessage ("El barco ha logrado llegar a la costa. Gracias por terminar la DEMO");
		gameManager.showPanel ();
		yield return null;
	}

	public IEnumerator endLooseGame(){
		gameManager.changeFinishMessage ("'Se nos debe liberar de la esperanza que el mar pueda reposar alguna vez. Debemos aprender a navergar con vientos fuertes' Aristoteles Onassis");
		StartCoroutine(Transitions._instance.animateObject( gameObject, boatDeadNewPosition,20));
		GameManager._instance.gameFinishFlag=true;
		yield return new WaitForSeconds(2);
		gameManager.showPanel ();
	}

}
