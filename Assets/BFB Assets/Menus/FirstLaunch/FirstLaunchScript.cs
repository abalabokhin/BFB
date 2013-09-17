using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;
using System;

public class FirstLaunchScript : MonoBehaviour
{
    public GUISkin menuSkin;
    public int mainMenuLevel;
    private string profileName = null;

    private void EnterName()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 400, 25));
        profileName = GUI.TextField(new Rect(0, 0, 100, 25), profileName ?? "Neeq");
        if (GUI.Button(new Rect(110, 0, 90, 25), "Enter"))
        {
            if (!string.IsNullOrEmpty(profileName))
            {
                SessionCache.Cache.CurrentPlayer = new Player() { Id = Guid.NewGuid(), Name = profileName };
                SessionCache.Cache.SaveCurrentPlayer();
                Application.LoadLevel(mainMenuLevel);
            }
        }
        GUI.EndGroup();
    }

    private void OnGUI()
    {
        GUI.skin = menuSkin;
        this.EnterName();
    }
}
