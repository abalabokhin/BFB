using UnityEngine;
using System.Collections;
using BFB.Cache;

public class StartScript : MonoBehaviour
{
	private LevelInspector levelInspector = null;

    void Start()
    {
		levelInspector = GlobalManagerInstance.GetLevelInspector();
		MetaCache.Cache.Init();
	}
	
    public GUISkin menuSkin;
    private void StartButton()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height - 150, 120, 50), "Start"))
        {
            //if no profile, force player to provide name
            if (string.IsNullOrEmpty(SessionCache.Cache.CurrentPlayer.Name))
            {
				levelInspector.LoadFirstLaunchMenu();
            }
            else //otherwise load next menu
            {
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
