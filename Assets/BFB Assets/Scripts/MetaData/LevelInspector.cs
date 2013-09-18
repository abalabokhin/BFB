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
		levels = levelNumbers;
	}
	
	private static int[] levels = new int[] {4, 5};
	
	public static int currentLevel = levels[0];
	
	private static int briefingLevel = 3;
	
	private static string[] levelBriefings = new string[] {"A long time ago \n in a galaxy far, far away....", "Your journey \n continues"};
	
	static public string GetCurrentBriefingText() { 
		if (!levels.Contains(currentLevel))
			return "";
		return levelBriefings[levels.ToList().IndexOf(currentLevel)];
	}
	
	static public void LoadLevel(int levelNumber) {
		Debug.Log("Loading level" + levelNumber);
		if (!levels.Contains(levelNumber))
			return;
		currentLevel = levelNumber;
		currentState = GameState.InGame;
		Application.LoadLevel(briefingLevel);
	}
	
	static public void NextLevel() {
		if (!levels.Contains(currentLevel))
			currentState = GameState.Finished;
		int currentLevelIndex = levels.ToList().IndexOf(currentLevel);
		if (currentLevelIndex < levels.Length - 1) {
			currentLevel = levels[currentLevelIndex + 1];
			currentState = GameState.LevelCompleted;
		} else {
			currentState = GameState.Finished;
		}
	}
	
	static public void StartCurrentLevel() {
		Debug.Log("Start level: " + currentLevel);
		currentState = GameState.InGame;
		Application.LoadLevel(currentLevel);
	}
	
	static public void StartCurrentBriefing() {
		Debug.Log("Start breafing: " + currentLevel);
		currentState = GameState.InGame;
		Application.LoadLevel(briefingLevel);
	}
}
