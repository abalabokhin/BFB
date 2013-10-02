using UnityEngine;
using System.Collections;
using BFB.Cache;

public class StartScript : MonoBehaviour
{
	private LevelInspector levelInspector = null;

    void Start()
    {
		levelInspector = levelInspector = GlobalManagerInstance.GetLevelInspector();
		MetaCache.Cache.Init();
	}
	
    public GUISkin menuSkin;
    private void StartButton()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height - 150, 120, 50), "Start"))
        {
            //if no profile, force player to provide name
            if (SessionCache.Cache.PlayerProfileExists() == false)
            {
				levelInspector.LoadFirstLaunchMenu();
            }
            else //otherwise load next menu
            {
                SessionCache.Cache.LoadCurrentPlayer();
				levelInspector.LoadMainMenu();
            }
        }
    }

    private void OnGUI()
    {
        GUI.skin = menuSkin;
        this.StartButton();
    }
}
