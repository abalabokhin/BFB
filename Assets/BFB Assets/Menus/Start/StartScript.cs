using UnityEngine;
using System.Collections;
using BFB.Cache;

public class StartScript : MonoBehaviour
{
	private LevelInspector levelInspector = null;

	void Start ()
	{
		Screen.showCursor = true;
		levelInspector = GlobalManagerInstance.GetLevelInspector ();
	}
	
	public GUISkin menuSkin;

	private void StartButton ()
	{
		if (GUI.Button (new Rect (Screen.width / 2 - 60, Screen.height - 150, 120, 50), "Start")) {
			levelInspector.LoadOpeningMenu ();
		}
	}

	private void OnGUI ()
	{
		GUI.skin = menuSkin;
		StartButton ();
	}
}
