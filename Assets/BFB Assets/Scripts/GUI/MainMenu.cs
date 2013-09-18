using UnityEngine;
using System.Collections;
using BFB.Cache;

public class MainMenu : MonoBehaviour {

	void OnGUI () {
		clearDistances();
		Time.timeScale = 0;
		switch (LevelInspector.currentState) {
			case LevelInspector.GameState.InGame:
				Time.timeScale = 1;
				enabled = false;
				break;
/*            case LevelInspector.GameState.JustStarted:
				createJustStartedMenu();
				break;*/
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
			case LevelInspector.GameState.Briefing:
				createBriefingMenu();
				break;
		}
	}		
	// TODO: Move all the string constants somewhere.

	// TODO: the next should depend on Screen.width & Screen.height, but for testing I hardcoded the values.
	int currentTop = 20;
	int buttomHeight = 30;
	int elementDistance = 20;
	int left = 300;
	int width = 200;
	int briefingHeight = 200;
	
	void clearDistances() {
		currentTop = 20;
		buttomHeight = 30;
		elementDistance = 20;
		left = 300;
		width = 200;
		briefingHeight = 200;
	}
	

	void createJustStartedMenu() {
		createWelcomeString("Welcome");
		createButtonStartBriefing("Start New Game");
		createButtonExit("Exit");
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
	
	void createBriefingMenu() {
		// TODO: get briefing in spite of the current level from XML from MetaCache.
		GUI.Box(new Rect(left, currentTop, width, briefingHeight), "A long time ago \n in a galaxy far, far away....");
		currentTop += (briefingHeight + elementDistance);
		createButtonRestartLevel("Continue");
	}
	
	void createButtonStartBriefing(string caption) {
		if (createButton(caption)) {
			Debug.Log("Start level from the begining");
			LevelInspector.currentState = LevelInspector.GameState.Briefing;
		}
	}
	
	void createButtonRestartLevel(string caption) {
		if (createButton(caption)) {
			Debug.Log("Restart Level");
			LevelInspector.currentState = LevelInspector.GameState.InGame;
			Time.timeScale = 1;
			enabled = false;
			Application.LoadLevel (Application.loadedLevel);
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
			Application.LoadLevel(2);
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
