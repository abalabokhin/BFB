using UnityEngine;
using System.Collections;
using BFB.Cache;

public class BriefingMenuScript : MonoBehaviour
{
	public GUISkin menuSkin;
	public Font font;
	private LevelInspector levelInspector = null;

	void Start ()
	{
		levelInspector = GlobalManagerInstance.GetLevelInspector ();
	}
	
	private void OnGUI ()
	{
		GUI.skin = menuSkin;
		GUI.skin.box.wordWrap = true;
		GUI.skin.box.fontSize = 18;
		GUI.skin.box.font = font;
		GUI.Box (new Rect (Screen.width / 2 - 200, 10, 400, 300), levelInspector.GetCurrentBriefingText ());
		GUI.BeginGroup (new Rect (Screen.width - 125, Screen.height - 150, 80, 100));
		if (GUI.Button (new Rect (0, 0, 80, 30), "Continue")) {
			levelInspector.StartCurrentLevel ();
		}
		GUI.Button (new Rect (0, 40, 80, 30), "Upgrades");
		GUI.EndGroup ();
	}

}
