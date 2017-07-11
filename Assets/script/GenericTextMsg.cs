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
		if(!Transitions._instance.animateFlag && !GameManager._instance.gameFinishFlag){
			animateMsgNoConditions (msg, gObj);
		}
	}

	public void animateMsgNoConditions (string msg, GameObject gObj)
	{
		Vector3 modPos = new Vector3 (0, 0, 0);
		if (Camera.main.WorldToScreenPoint (gObj.transform.position).x > Screen.width / 2) {
			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
			text.gameObject.transform.localScale = new Vector3 (-1, 1, 1);
		}
		else {
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
			text.gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (gameObject.GetComponent<RectTransform> ().rect.height * 2 + Camera.main.WorldToScreenPoint (gObj.transform.position).y > Screen.height) {
			Vector3 pos = gameObject.transform.position;
			modPos += new Vector3 (0, gameObject.GetComponent<RectTransform> ().rect.height / 2, 0);
			Debug.Log ("DEAM");
		}
		gameObject.SetActive (true);
		gameObject.transform.position = Camera.main.WorldToScreenPoint (gObj.transform.position) - modPos;
		text.text = "" + msg;
		StartCoroutine (Transitions._instance.animateAndHideObject (gameObject, 90));
	}



}
