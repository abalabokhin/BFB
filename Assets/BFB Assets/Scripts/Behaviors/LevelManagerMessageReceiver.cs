using UnityEngine;
using System.Collections;
using BFB.Cache;

public class LevelManagerMessageReceiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    // show menu if 'esc' key pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<GameMenu>().enabled = true;
            SessionCache.Cache.LevelInspector.currentState = LevelInspector.GameState.Pause;
        }
	}
	
	void OnPlayerDestroyed() {
		GameMenu menu = gameObject.GetComponent<GameMenu>();
        if (menu != null)
        {
        	menu.enabled = true;
        }
        SessionCache.Cache.LevelInspector.currentState = LevelInspector.GameState.Destroyed;
	}
}
