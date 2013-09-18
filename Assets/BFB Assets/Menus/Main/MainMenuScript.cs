using UnityEngine;
using System.Collections;
using BFB.Cache;

public class MainMenuScript : MonoBehaviour
{
    public GUISkin menuSkin;
	public int[] levels = {4, 5};

	void Start ()
	{
		LevelInspector.SetLevelNumbers(levels);
	}
	
    private void Levels()
    {
        GUI.BeginGroup(new Rect(Screen.width - 125, Screen.height - 150, 80, 100));
		
		// TODO: do it in cycle
        if (GUI.Button(new Rect(0, 0, 80, 30), "Level 1"))
        {
			LevelInspector.LoadLevel(levels[0]);
        }
        if (GUI.Button(new Rect(0, 40, 80, 30), "Level 2"))
        {
			LevelInspector.LoadLevel(levels[1]);
        }
        GUI.EndGroup();
    }

    private void OnGUI()
    {
        GUI.skin = menuSkin;
        this.Levels();
    }
}
