using UnityEngine;
using System.Collections;

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
	
	public static GameState currentState = LevelInspector.GameState.JustStarted;
	
	private static string[] levels = {"BFB", "BFB2"};
	
	private static int currentLevelNumber = 0;
	
	static public void NextLevel() {
		if (currentLevelNumber < levels.Length - 1) {
			++currentLevelNumber;
			Application.LoadLevel(levels[currentLevelNumber]);
			currentState = GameState.LevelCompleted;
		} else {
			currentState = GameState.Finished;
		}
	}
}
