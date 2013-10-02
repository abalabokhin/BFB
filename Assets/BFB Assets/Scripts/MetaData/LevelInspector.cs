using UnityEngine;
using System.Collections;
using System.Linq;
using BFB.Cache;

public class LevelInspector : MonoBehaviour {
	public enum GameState {
		InGame,
		Pause,
		Destroyed,
		LevelCompleted,
		Finished
	};
	
	public GameState currentState = LevelInspector.GameState.InGame;
	
	public void SetLevelNumbers(int[] levelNumbers) {
		gameLevels = levelNumbers;
	}
	
	private int[] gameLevels = new int[] {4, 5};
	private int briefingLevel = 3;
	private int mainLevel = 2;
	private int firstLaunchLevel = 1;
	private int currentLevelIndex = 0;
	
	private string[] levelBriefings = new string[] {"A long time ago \n in a galaxy far, far away....", "Your journey \n continues"};
	
	void Update () {
	    // show menu if 'esc' key pressed.
        if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.InGame)
        {
            gameObject.GetComponent<GameMenu>().enabled = true;
            currentState = GameState.Pause;
        }
	}
	
	public void OnPlayerDestroyed() {
		GameMenu menu = gameObject.GetComponent<GameMenu>();
        if (menu != null)
        {
        	menu.enabled = true;
        }
		Debug.Log ("Player Destroyed");
        currentState = GameState.Destroyed;
	}
	
	public int levelAmount
	{ 
		get { return gameLevels.Length; }
	}
	
	public string GetCurrentBriefingText() { 
		if (currentLevelIndex >= gameLevels.Length)
			return "";
		return levelBriefings[currentLevelIndex];
	}
	
	public void LoadGameLevel(int gameLevelIndex) {
		Debug.Log("Loading level " + gameLevelIndex);
		if (gameLevelIndex >= gameLevels.Length)
			return;
		currentLevelIndex = gameLevelIndex;
		currentState = GameState.InGame;
		Application.LoadLevel(briefingLevel);
	}
	
	public void NextLevel() {
		gameObject.GetComponent<GameMenu>().enabled = true;
		if (currentLevelIndex >= gameLevels.Length - 1) {
			currentState = GameState.Finished;
			return;
		}
		++currentLevelIndex;
		currentState = GameState.LevelCompleted;
	}
	
	public void StartCurrentLevel() {
		currentState = GameState.InGame;
		Debug.Log("Start level: " + currentLevelIndex);
		Application.LoadLevel(gameLevels[currentLevelIndex]);
	}
	
	public void StartCurrentBriefing() {
		Debug.Log("Start breafing: " + currentLevelIndex);
		currentState = GameState.InGame;
		Application.LoadLevel(briefingLevel);
	}
	
	public void LoadMainMenu() {
		gameObject.GetComponent<GameMenu>().enabled = false;
		Application.LoadLevel(mainLevel);
	}
	
	public void LoadFirstLaunchMenu ()
	{
		gameObject.GetComponent<GameMenu>().enabled = false;
		Application.LoadLevel(firstLaunchLevel);
	}
}
