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
		switch (LevelInspector.currentState) {
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
	int buttomHeight;
	int elementDistance;
	int left;
	int width;
	
	void clearDistances() {
		// TODO: the next should depend on Screen.width & Screen.height, but for testing I hardcoded some values.
		currentTop = 20;
		buttomHeight = 30;
		elementDistance = 20;
		left = Screen.width / 2 - 100;
		width = 200;
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
			LevelInspector.StartCurrentBriefing();
		}
	}

	void createButtonRestartLevel(string caption) {
		if (createButton(caption)) {
			Debug.Log("Restart Level");
			LevelInspector.StartCurrentLevel();
			Time.timeScale = 1;
			enabled = false;
		}
	}
	
	void createButtonContinueLevel(string caption) {
		if (createButton(caption)) {
			LevelInspector.currentState = LevelInspector.GameState.InGame;
			Time.timeScale = 1;
			enabled = false;
		}
	}
	
	void createButtonExit(string caption) {
		if (createButton(caption)) {
			Debug.Log("Quit");
			LevelInspector.LoadMainMenu();
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
