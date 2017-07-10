using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transitions : MonoBehaviour {

	public static Transitions _instance;
	public bool animateFlag;

	void Start () {
		if(_instance==null){
			_instance=this;
		}
	}
		
	public IEnumerator animateAndHideObject(GameObject obj,float move){
		if(!animateFlag){
			animateFlag = true;	
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

	public IEnumerator animateObject(GameObject obj,GameObject obj2,float newTime){
			float timeStart=Time.time;
			float totalTime=newTime;
			while(Vector3.Distance(obj.transform.position,obj2.transform.position)>0.05f){
				float time=Time.time-timeStart;
				float percentageComplete=time/totalTime;
				obj.transform.position = Vector3.Lerp (obj.transform.position, obj2.transform.position, percentageComplete);
				Debug.Log("P:"+percentageComplete);
				yield return null;
			}
			Debug.Log("End move Obj");
	}

	public IEnumerator animateObject(GameObject obj,Vector3 obj2,float newTime){
		float timeStart=Time.time;
		float totalTime=newTime;
		while(Vector3.Distance(obj.transform.position,obj2)>0.5f){
			float time=Time.time-timeStart;
			float percentageComplete=time/totalTime;
			obj.transform.position = Vector3.Lerp (obj.transform.position, obj2, percentageComplete);
			Debug.Log("P:"+percentageComplete);
			yield return null;
		}
		Debug.Log("End move Obj");
	}

	public IEnumerator fadeOutSprite(GameObject obj,float delay){
		Color color = obj.GetComponent<SpriteRenderer> ().color;
		while (obj.GetComponent<SpriteRenderer> ().color.a > 0.05){
			color.a = Mathf.Lerp (color.a, 0,0.1f);
			obj.GetComponent<SpriteRenderer> ().color=color;
			yield return new WaitForSeconds (delay);
		}
		obj.SetActive (false);
		yield return null;
	}

	public IEnumerator fadeInSprite(GameObject obj,float delay){
		obj.SetActive (true);
		Color color = obj.GetComponent<SpriteRenderer> ().color;
		color.a = 0;
		obj.GetComponent<SpriteRenderer> ().color = color;
		while (obj.GetComponent<SpriteRenderer> ().color.a < 0.95){
			color.a = Mathf.Lerp (color.a, 1,0.1f/(1+delay));
			obj.GetComponent<SpriteRenderer> ().color=color;
			yield return new WaitForSeconds (delay);
		}
		color.a = 1;
		obj.GetComponent<SpriteRenderer> ().color = color;
		yield return null;
	}

	public IEnumerator fadeOutImage(GameObject obj,float delay){
		Color color = obj.GetComponent<Image> ().color;
		while (obj.GetComponent<Image> ().color.a > 0.05){
			color.a = Mathf.Lerp (color.a, 0,0.1f);
			obj.GetComponent<Image> ().color=color;
			yield return new WaitForSeconds (delay);
		}
		obj.SetActive (false);
		yield return null;
	}

	public IEnumerator fadeInImage(GameObject obj,float delay){
		obj.SetActive(true);
		Color color = obj.GetComponent<Image> ().color;
		color.a = 0;
		obj.GetComponent<Image> ().color = color;

		while (obj.GetComponent<Image> ().color.a < 0.95){
			color.a = Mathf.Lerp (color.a, 1,0.1f/(1+delay));
			obj.GetComponent<Image> ().color=color;
			yield return new WaitForSeconds (delay);
		}
		color.a = 1;
		obj.GetComponent<Image> ().color = color;
		yield return null;
	}
}
