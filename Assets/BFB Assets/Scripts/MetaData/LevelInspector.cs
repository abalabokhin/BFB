using UnityEngine;
using System.Collections;
using System.Linq;

public class LevelInspector {
	public enum GameState {
		JustStarted,
		InGame,
		Briefing,
		Pause,
		Destroyed,
		LevelCompleted,
		Finished
	};
	
	public static GameState currentState = LevelInspector.GameState.Briefing;
	
	public static void SetLevelNumbers(int[] levelNumbers) {
		Debug.Log("All the level numbers: " + levelNumbers);
		levels = levelNumbers;
	}
	
	private static int[] levels;
	
	public static int currentLevel = 0;
	
	static public void LoadLevel(int levelNumber) {
		Debug.Log("Loading level" + levelNumber);
		if (!levels.Contains(levelNumber))
			return;
		currentLevel = levelNumber;
		currentState = GameState.Briefing;
		Application.LoadLevel(currentLevel);
	}
	
	static public void NextLevel() {
		if (!levels.Contains(currentLevel))
			return;
		int currentLevelIndex = levels.ToList().IndexOf(currentLevel);
		if (currentLevelIndex < levels.Length - 1) {
			currentLevel = levels[currentLevelIndex + 1];
			Application.LoadLevel(currentLevel);
			currentState = GameState.LevelCompleted;
		} else {
			currentState = GameState.Finished;
		}
	}
}
