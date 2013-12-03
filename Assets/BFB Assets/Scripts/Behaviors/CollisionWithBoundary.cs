using UnityEngine;
using System.Collections;
using BFB.Cache;

public class CollisionWithBoundary : MonoBehaviour
{
	
	//public GameObject player;
	/*public*/
	GameObject boundary;
	float timer = 20;
	float countdown;
	bool showText = false;
	string text = "";
	//public BoxCollider boundS;
	
	// Use this for initialization
	void Start ()
	{
		boundary = GameObject.FindGameObjectWithTag (Tags.boundary);
		countdown = timer;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (countdown <= 0) {
			countdown = 0;
			//Debug.Log ("DEAD");
			SendMessage ("DestroyObject", boundary, SendMessageOptions.DontRequireReceiver);
		}
		
//		if(showText){
//			countdown -= Time.deltaTime;
//		}
//		else
//			countdown = timer;
		
		KeepInBounds ();
	}
	
	void KeepInBounds ()
	{		
		BoxCollider box = boundary.GetComponent<BoxCollider> ();
		if (!box.bounds.Contains (transform.position)) {
			//Debug.Log ("Out of bounds");
			countdown -= Time.deltaTime;
			showText = true;
		} else {
			//Debug.Log ("In bounds");
			countdown = timer;
			showText = false;
		}
	}
	
	void OnGUI ()
	{
		float stdW = 320;
		float stdH = 50;
		float currX = (Screen.width - stdW) / 2;
		float currY = (Screen.height - stdH) / 2;

		GUI.Label (new Rect (currX, currY, stdW, stdH), text);
		GUI.contentColor = Color.grey;
		if (showText) {
			text = "You've gone out of bounds! Turn around or die in ... ";
			GUI.Label (new Rect (currX, currY, stdW, stdH), text + (int)Mathf.Round (countdown));
		} else {
			text = "";
			GUI.Label (new Rect (currX, currY, stdW, stdH), text);
		}
	}
}
