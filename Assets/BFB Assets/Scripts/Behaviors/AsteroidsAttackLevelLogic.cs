﻿using UnityEngine;
using System.Collections;

public class AsteroidsAttackLevelLogic : MonoBehaviour {
	public float minimumDistanceFromPlanetToMeteors = 100;
	public float maximumDistanceFromPlanetToMeteors = 500;
	/// time between next meteor generation.
	public float dtInSecs = 5;
	public float maxMeteorInitialForce = 50;
	public float maxScalling = 3;
	
	
	private float maxRotationForce = 3;
	float generatedAt = 0;
	
	GameObject planet;
	
	public float timeToSurvive = 100;
	private float startTime = 0;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		planet = GameObject.FindGameObjectWithTag(BFB.Cache.Tags.planet);
	}
	
	void OnGUI() {
		//if (GlobalManagerInstance.GetLevelInspector().currentState != LevelInspector.GameState.InGame)
		//	return;
		float stdW = 320;
		float stdH = 30;
		float currX = 10;
		float currY = Screen.height - 30 - 10;
		
		float secondsLeft = timeToSurvive + startTime - Time.time;
		
		if (secondsLeft <= 0)
		{
			//Debug.Log (Environment.StackTrace);
			//GlobalManagerInstance.GetLevelInspector().NextLevel();
			GameObject.FindGameObjectWithTag(BFB.Cache.Tags.player).SendMessage("WinLevel");
		}
		
		GUI.Label (new Rect (currX, currY, stdW, stdH), string.Format("Seconds left to survive {0}", secondsLeft));
	}
	
	// Update is called once per frame
	void Update () {
		tryToGeneratenewAsteroid();
	}
	
	void tryToGeneratenewAsteroid() {
		if (generatedAt + dtInSecs > Time.time)
			return;
			
		generatedAt = Time.time;
		
		Vector3 planetPosition = planet.transform.position;
		Vector3 meteorPosition = planetPosition;
		while ((meteorPosition - planetPosition).magnitude < minimumDistanceFromPlanetToMeteors) {
			Vector3 randomPosition = Random.insideUnitSphere * maximumDistanceFromPlanetToMeteors;
			meteorPosition.x = randomPosition.x;
			meteorPosition.y = randomPosition.y;
			meteorPosition.z = randomPosition.z;
		}
		
		GameObject newAsteroid = Instantiate(Resources.Load("Asteroid1"), meteorPosition, Random.rotation) as GameObject;
		
		float meteorSize = Random.value * maxScalling;
		newAsteroid.transform.localScale += new Vector3(3, 3, 3);
		newAsteroid.transform.localScale += new Vector3(meteorSize,  meteorSize, meteorSize);
		newAsteroid.rigidbody.AddTorque(Random.insideUnitSphere * maxRotationForce);
		newAsteroid.rigidbody.AddForce(Random.insideUnitSphere * maxMeteorInitialForce);
	}
}
