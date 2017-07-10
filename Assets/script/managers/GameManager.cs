using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public bool touchBottleFlag;
	public bool touchPaperFlag;
	public bool lightHouseOnFlag;
	public bool stormLeaveFlag;
	public bool boatActiveFlag;
	public bool squidApearFlag;
	public bool squidBusyFlag;
	public bool shoalLeaveFlag;
	public bool gameActionFlag;
	public Text message;
	public Text finishMessage;
	public GameObject panelMenu;  
	public bool animateFlag=false;
	public GameObject fadeScreen;
	public bool gameFinishFlag=false;
	public static GameManager _instance;



	// Use this for initialization
	void Start () {
		panelMenu.SetActive (false);
		fadeScreen.SetActive(true);
		StartCoroutine(playFade());
		if(_instance==null){
			_instance=this;
		}
	}

	IEnumerator playFade(){
		yield return new WaitForSeconds(0.5f);
		StartCoroutine( Transitions._instance.fadeOutImage(fadeScreen,0.1f));
	}

	// Update is called once per frame
	void Update () {
		
	}

	void writeVariables () {
		Debug.Log ("touchBottleFlag:" + touchBottleFlag);
		Debug.Log ("touchBottleFlag;" + touchBottleFlag);  
		Debug.Log ("touchPaperFlag;" + touchBottleFlag); 
		Debug.Log ("lightHouseOnFlag;" + touchPaperFlag);
		Debug.Log ("stormLeaveFlag;" + lightHouseOnFlag);
		Debug.Log ("boatActiveFlag;" + boatActiveFlag);
		Debug.Log ("gameActionFlag;" + gameActionFlag);
	}
			
	public void changeMessage(string txt){
		message.text=txt;
	}

	public void changeFinishMessage(string txt){
		finishMessage.text=txt;
	}

	public void showPanel(){
		panelMenu.SetActive (true);
	}
		
}