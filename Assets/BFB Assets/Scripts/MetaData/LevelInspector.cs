using UnityEngine;
using System.Collections;
using System.Linq;

public class LevelInspector {
	public enum GameState {
		InGame,
		Pause,
		Destroyed,
		LevelCompleted,
		Finished
	};
	
	public static GameState currentState = LevelInspector.GameState.InGame;
	
	public static void SetLevelNumbers(int[] levelNumbers) {
		gameLevels = levelNumbers;
	}
	
	private static int[] gameLevels = new int[] {4, 5};
	private static int briefingLevel = 3;
	private static int mainLevel = 2;
	private static int firstLaunchLevel = 1;
	private static int currentLevelIndex = 0;
	
	private static string[] levelBriefings = new string[] {"A long time ago \n in a galaxy far, far away....", "Your journey \n continues"};
	
	static public int levelAmount
	{ 
		get { return gameLevels.Length; }
	}
	
	static public string GetCurrentBriefingText() { 
		if (currentLevelIndex >= gameLevels.Length)
			return "";
		return levelBriefings[currentLevelIndex];
	}
	
	static public void LoadGameLevel(int gameLevelIndex) {
		Debug.Log("Loading level " + gameLevelIndex);
		if (gameLevelIndex >= gameLevels.Length)
			return;
		currentLevelIndex = gameLevelIndex;
		currentState = GameState.InGame;
		Application.LoadLevel(briefingLevel);
	}
	
	static public void NextLevel() {
		if (currentLevelIndex >= gameLevels.Length - 1) {
			currentState = GameState.Finished;
			return;
		}
		currentState = GameState.LevelCompleted;
	}
	
	static public void StartCurrentLevel() {
		Debug.Log("Start level: " + currentLevelIndex);
		currentState = GameState.InGame;
		Application.LoadLevel(gameLevels[currentLevelIndex]);
	}
	
	static public void StartCurrentBriefing() {
		Debug.Log("Start breafing: " + currentLevelIndex);
		currentState = GameState.InGame;
		Application.LoadLevel(briefingLevel);
	}
	
	static public void LoadMainMenu() {
		Application.LoadLevel(mainLevel);
	}
	
	public static void LoadFirstLaunchMenu ()
	{
		Application.LoadLevel(firstLaunchLevel);
	}
}
