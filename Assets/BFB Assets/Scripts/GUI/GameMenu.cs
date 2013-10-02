using UnityEngine;
using System.Collections;
using BFB.Cache;

public class GameMenu : MonoBehaviour {
	void Start() {
		clearDistances();
	}
	
	void OnGUI () {
		clearDistances();
		Time.timeScale = 0;
		switch (SessionCache.Cache.LevelInspector.currentState) {
			case LevelInspector.GameState.InGame:
				Time.timeScale = 1;
				enabled = false;
				break;
			case LevelInspector.GameState.Pause:
				createPauseMenu();
				break;
			case LevelInspector.GameState.Destroyed:
				createDestroyedMenu();
				break;
			case LevelInspector.GameState.LevelCompleted:
				createLevelCompletedMenu();
				break;
			case LevelInspector.GameState.Finished:
				createFinishedMenu();
				break;
		}
	}		
	// TODO: Move all the string constants somewhere.

	int currentTop;
	int buttomHeight = 30;
	int elementDistance = 20;
	int left = Screen.width / 2 - 100;
	int width = 200;
	
	void clearDistances() {
		currentTop = 20;
	}
	
	void createPauseMenu() {
		createWelcomeString("Pause");
		createButtonContinueLevel("Continue");
		createButtonRestartLevel("Restart");
		createButtonExit("Exit");
	}

	void createDestroyedMenu() {
		createWelcomeString("You were close!");
		createButtonRestartLevel("Try Again?");
		createButtonExit("Exit");
		
	}

	void createLevelCompletedMenu() {
		// TODO: May be here we should change level? Return to the code when there is more than one level.
		createWelcomeString("Congretulations!!!");
		createButtonStartBriefing("Next Level");
		createButtonExit("Exit");
	}
	
	void createFinishedMenu() {
		createWelcomeString("Congretulations!!! You won the game");
		createButtonExit("Exit");
	}
	
	void createButtonStartBriefing(string caption) {
		if (createButton(caption)) {
			Debug.Log("Start level from the begining");
			SessionCache.Cache.LevelInspector.StartCurrentBriefing();
		}
	}

	void createButtonRestartLevel(string caption) {
		if (createButton(caption)) {
			Debug.Log("Restart Level");
			SessionCache.Cache.LevelInspector.StartCurrentLevel();
		}
	}
	
	void createButtonContinueLevel(string caption) {
		if (createButton(caption)) {
			SessionCache.Cache.LevelInspector.currentState = LevelInspector.GameState.InGame;
		}
	}
	
	void createButtonExit(string caption) {
		if (createButton(caption)) {
			Debug.Log("Quit");
			SessionCache.Cache.LevelInspector.LoadMainMenu();
		};
	}
				
	void createWelcomeString(string caption) {
		GUI.Box(new Rect(left, currentTop, width, buttomHeight), caption);
		currentTop += (buttomHeight + elementDistance);
	}
	
	bool createButton(string caption) {
		bool result = GUI.Button(new Rect(left, currentTop, width, buttomHeight), caption);
		currentTop += (buttomHeight + elementDistance);
		return result;
	}
}
