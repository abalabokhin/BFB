using UnityEngine;
using System.Collections;
using BFB.Cache;

public class MainMenuScript : MonoBehaviour
{
    public GUISkin menuSkin;
    public int level1;
    public int level2;

    private void Levels()
    {
        GUI.BeginGroup(new Rect(Screen.width - 125, Screen.height - 150, 80, 100));
        if (GUI.Button(new Rect(0, 0, 80, 30), "Level 1"))
        {
            Application.LoadLevel(level1);
        }
        if (GUI.Button(new Rect(0, 40, 80, 30), "Level 2"))
        {
            Application.LoadLevel(level2);
        }
        GUI.EndGroup();
    }

    private void OnGUI()
    {
        GUI.skin = menuSkin;
        this.Levels();
    }
}
