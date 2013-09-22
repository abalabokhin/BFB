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
		if (currentLevelIndex >= gameLevels.Length - 1) {
			currentState = GameState.Finished;
			return;
		}
		++currentLevelIndex;
		currentState = GameState.LevelCompleted;
	}
	
	public void StartCurrentLevel() {
		Time.timeScale = 1;
		Debug.Log("Start level: " + currentLevelIndex);
		currentState = GameState.InGame;
		Application.LoadLevel(gameLevels[currentLevelIndex]);
	}
	
	public void StartCurrentBriefing() {
		Debug.Log("Start breafing: " + currentLevelIndex);
		currentState = GameState.InGame;
		Application.LoadLevel(briefingLevel);
	}
	
	public void LoadMainMenu() {
		Application.LoadLevel(mainLevel);
	}
	
	public void LoadFirstLaunchMenu ()
	{
		Application.LoadLevel(firstLaunchLevel);
	}
}
