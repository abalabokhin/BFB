using UnityEngine;
using System.Collections;
using BFB.Cache;

public class MainMenuScript : MonoBehaviour
{
    public GUISkin menuSkin;
	private int gameLevelAmount;
	private int levelAmount = 0;
	
	void Start ()
	{
		levelAmount = SessionCache.Cache.LevelInspector.levelAmount;
	}
	
    private void Levels()
    {
		int height = 30;
		int elementDistance = 10;
		int currentTop = 0;
		
        GUI.BeginGroup(new Rect(Screen.width - 125, Screen.height - 150, 80, levelAmount * (elementDistance + height)));
		
		for (int i = 0; i < levelAmount; ++i) {
			if (GUI.Button(new Rect(0, currentTop, 80, height), string.Format("Level {0}", i + 1)))
        	{
				SessionCache.Cache.LevelInspector.LoadGameLevel(i);
        	}
			currentTop += (height + elementDistance);
		}
        GUI.EndGroup();
    }

    private void OnGUI()
    {
        GUI.skin = menuSkin;
        this.Levels();
    }
}
