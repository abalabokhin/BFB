﻿using UnityEngine;
using System.Collections;
using BFB.Models;
using BFB.Cache;

public class HUD : MonoBehaviour
{
	public GUIText shipName;
	private int playClicks = 0;

	// Use this for initialization
	void Start ()
	{
		if (shipName != null) {
			shipName.text = gameObject.GetComponent<PlayerWrapper> ().Name;
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	private void OnGUI ()
	{
		float stdW = 360;
		float stdH = 50;
		float currX = (Screen.width - stdW) / 2;
		float currY = Screen.height - stdH;
		GUI.BeginGroup (new Rect (currX, currY, stdW, stdH));
		if (GUI.Button (new Rect (10, 0, 100, 20), "Play/Stop")) {
			playClicks++;
			AudioPlays (playClicks);
		}
		GUI.Label (new Rect (130, 0, 100, 50), string.Format ("Fuel: {0}", gameObject.GetComponent<PlayerWrapper> ().Fuel));
		GUI.Label (new Rect (250, 0, 100, 50), string.Format ("Health: {0}", gameObject.GetComponent<CollisionDamageController> ().health));
		GUI.EndGroup ();
	}
	
	private void AudioPlays (int hits)
	{
		if (hits % 2 == 1) {
				GetComponent<AudioSource> ().Play ();
		}
		if (hits % 2 == 0) {
				GetComponent<AudioSource> ().Stop ();
		}
	}
}
