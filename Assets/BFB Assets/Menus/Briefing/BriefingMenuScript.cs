﻿using UnityEngine;
using System.Collections;
using BFB.Cache;

public class BriefingMenuScript : MonoBehaviour {
	public GUISkin menuSkin;
	
	private void OnGUI()
    {
		GUI.skin = menuSkin;
		GUI.Box(new Rect(Screen.width / 2 - 200, 10, 400, 300), SessionCache.Cache.LevelInspector.GetCurrentBriefingText());
		GUI.BeginGroup(new Rect(Screen.width - 125, Screen.height - 150, 80, 100));
		if (GUI.Button(new Rect(0, 0, 80, 30), "Continue")) {
			SessionCache.Cache.LevelInspector.StartCurrentLevel();
		}
		GUI.Button(new Rect(0, 40, 80, 30), "Upgrades");
		GUI.EndGroup();
    }

}
