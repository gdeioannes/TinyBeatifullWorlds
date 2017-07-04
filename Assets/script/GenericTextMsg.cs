using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericTextMsg : MonoBehaviour {

	public static GenericTextMsg _instance;

	public GameManager gameManager;
	public Text text;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		if(_instance==null){
			_instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void animateMsg(string msg,GameObject gObj){
		if(Camera.main.WorldToScreenPoint(gObj.transform.position).x>Screen.width/2){
			gameObject.transform.localScale=new Vector3(-1,1,1);
			text.gameObject.transform.localScale=new Vector3(-1,1,1);
		}else{
			gameObject.transform.localScale=new Vector3(1,1,1);
			text.gameObject.transform.localScale=new Vector3(1,1,1);
		}
		gameObject.SetActive(true);
		gameObject.transform.position=Camera.main.WorldToScreenPoint(gObj.transform.position);
		text.text=""+msg;
		StartCoroutine( gameManager.animateAndHideObject(gameObject,90));
	}
}
