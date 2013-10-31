using UnityEngine;
using System.Collections;
using BFB.Cache;

public class MainMenuScript : MonoBehaviour
{
    public GUISkin menuSkin;
	private int gameLevelAmount;
	private LevelInspector levelInspector = null;

    void Start()
    {
		levelInspector = GlobalManagerInstance.GetLevelInspector();
	}
	
    private void Levels()
    {
		int height = 30;
		int elementDistance = 10;
		int currentTop = 0;
		
        GUI.BeginGroup(new Rect(Screen.width - 125, Screen.height - 150, 80, (levelInspector.levelAmount + 1) * (elementDistance + height)));
		
		for (int i = 0; i < levelInspector.levelAmount; ++i) {
			if (GUI.Button(new Rect(0, currentTop, 80, height), string.Format("Level {0}", i + 1)))
        	{
				levelInspector.LoadGameLevel(i);
        	}
			currentTop += (height + elementDistance);
		}
		if (GUI.Button(new Rect(0, currentTop, 80, height), "Quit"))
        {
			Application.Quit();
        }
		
        GUI.EndGroup();
    }

    private void OnGUI()
    {
        GUI.skin = menuSkin;
        this.Levels();
    }
}
