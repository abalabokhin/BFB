using UnityEngine;
using System.Collections;
using BFB.Models;
using BFB.Cache;

public class HUD : MonoBehaviour {
	
	public GUIText ShipName;

	// Use this for initialization
	void Start () {
		if (ShipName != null) {
			ShipName.text = "Dr. Dre";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnGUI()
    {
		
		GUI.BeginGroup(new Rect(Screen.width - 320, Screen.height - 50, 320, 50));
		GUI.Label(new Rect(0,0,150,50),string.Format("Fuel: {0}", SessionCache.Cache.CurrentPlayer.Ship.Fuel));
		GUI.Label(new Rect(170,0,150,50),string.Format("Health: {0}", SessionCache.Cache.CurrentPlayer.Ship.Health));
        GUI.EndGroup();
    }
}
