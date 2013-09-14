using UnityEngine;
using System.Collections;

public class LevelInspector {
	public enum GameState {
		JustStarted,
		InGame,
		Briefing,
		Pause,
		Destroyed,
		Finished
	};
	
	public static GameState currentState = LevelInspector.GameState.JustStarted;
}
