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
	public bool squidBusyFlag;
	public bool shoalLeaveFlag;
	public bool gameActionFlag;
	public Text message;
	public Text finishMessage;
	public GameObject panelMenu;  
	public bool animateFlag=false;
	public GameObject fadeScreen;
	public bool gameFinishFlag=false;




	// Use this for initialization
	void Start () {
		panelMenu.SetActive (false);
		fadeScreen.SetActive(true);
		StartCoroutine( fadeOutSpriteImage(fadeScreen,0.1f));
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

	public IEnumerator animateAndHideObject(GameObject obj,float move){
			
			if(!animateFlag){
				animateFlag = true;	
				Debug.Log ("Star Transition");
				obj.SetActive (true);
				Vector3 positionSave = obj.transform.position;
				Vector3 postionNew = new Vector3 (obj.transform.position.x, obj.transform.position.y + move, obj.transform.position.z);
				int count = 0;
				int wait = 30;
				while (count < wait) {
					obj.transform.position = Vector3.Lerp (obj.transform.position, postionNew, 0.1f);
					yield return new WaitForSeconds (0.05f);
					count++;
				}
				yield return new WaitForSeconds (0.5f);
				obj.transform.position = positionSave;
				obj.SetActive (false);
				animateFlag = false;
			}

	}

	public IEnumerator animateObject(GameObject obj,GameObject obj2){
		if(!animateFlag){
			animateFlag = true;	
			Debug.Log ("Star Transition");
			while(Vector3.Distance(obj.transform.position,obj2.transform.position)>0){
				obj.transform.position = Vector3.Lerp (obj.transform.position, obj2.transform.position, 0.1f);
				yield return new WaitForSeconds (0.05f);
				animateFlag = false;
			}
		}
	}

	public IEnumerator fadeOutSprite(GameObject obj,float delay){
			Debug.Log ("Star Alpha Transition");
			Color color = obj.GetComponent<SpriteRenderer> ().color;
			Debug.Log ("Alpha " + color.a);
			while (obj.GetComponent<SpriteRenderer> ().color.a > 0.05){
				Debug.Log ("Alpha "+color.a );
			color.a = Mathf.Lerp (color.a, 0,0.1f);
				obj.GetComponent<SpriteRenderer> ().color=color;
			yield return new WaitForSeconds (delay);
			}
			obj.SetActive (false);
		yield return null;
		
	}

	public IEnumerator fadeOutSpriteImage(GameObject obj,float delay){
		Debug.Log ("Star Alpha Transition");
		Color color = obj.GetComponent<Image> ().color;
		Debug.Log ("Alpha " + color.a);
		while (obj.GetComponent<Image> ().color.a > 0.05){
			Debug.Log ("Alpha "+color.a );
			color.a = Mathf.Lerp (color.a, 0,0.1f);
			obj.GetComponent<Image> ().color=color;
			yield return new WaitForSeconds (delay);
		}
		obj.SetActive (false);
		yield return null;

	}

	public IEnumerator fadeInSprite(GameObject obj,float delay){
		obj.SetActive (true);
		Debug.Log ("Star Alpha Transition");
		Color color = obj.GetComponent<SpriteRenderer> ().color;
		color.a = 0;
		obj.GetComponent<SpriteRenderer> ().color = color;

		Debug.Log ("Alpha " + color.a);
		while (obj.GetComponent<SpriteRenderer> ().color.a < 0.95){
			Debug.Log ("Alpha "+color.a );
			color.a = Mathf.Lerp (color.a, 1,0.1f);
			obj.GetComponent<SpriteRenderer> ().color=color;
			yield return new WaitForSeconds (delay);
		}
		color.a = 1;
		obj.GetComponent<SpriteRenderer> ().color = color;
		yield return null;

	}

}