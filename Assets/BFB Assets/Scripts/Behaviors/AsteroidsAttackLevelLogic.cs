using UnityEngine;
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
	
	enum LevelState {
		asteroidAttack,
		bigAsteroid,
		newHome
	};
	
	LevelState state = LevelState.asteroidAttack;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor  = false;
		startTime = Time.time;
		planet = GameObject.FindGameObjectWithTag(BFB.Cache.Tags.planet);
	}
	
	void OnGUI() {
		if (state == LevelState.asteroidAttack) {
		
			float stdW = 320;
			float stdH = 30;
			float currX = 10;
			float currY = Screen.height - 30 - 10;
			
			float secondsLeft = timeToSurvive + startTime - Time.time;
			
			if (secondsLeft <= 0)
			{
				//Debug.Log (Environment.StackTrace);
				//GlobalManagerInstance.GetLevelInspector().NextLevel();
				//GameObject.FindGameObjectWithTag(BFB.Cache.Tags.player).SendMessage("WinLevel");
				generateNewAsteroid(100, 1000);
				state = LevelState.bigAsteroid;
			}
			
			GUI.Label (new Rect (currX, currY, stdW, stdH), string.Format("Seconds left to survive {0}", secondsLeft));
			
		} else if (state == LevelState.bigAsteroid) {
			if (planet == null)
				state = LevelState.newHome;

		} else if (state == LevelState.newHome) {
		
			float stdW = 500;
			float stdH = 30;
			float currX = 10;
			float currY = Screen.height - 30 - 10;
			
			GUI.Label (new Rect (currX, currY, stdW, stdH), "Now you are the only hope of humanity, try to find new home!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		tryToGeneratenewAsteroid();
	}
	
	void tryToGeneratenewAsteroid() {
		if (state != LevelState.asteroidAttack)
			return;
		if (generatedAt + dtInSecs > Time.time)
			return;
			
		generatedAt = Time.time;
		
		generateNewAsteroid(0, 1);
	}
	
	void generateNewAsteroid(int size, int damageAmount) {

		Vector3 planetPosition = planet.transform.position;
		Vector3 meteorPosition = planetPosition;
		while ((meteorPosition - planetPosition).magnitude < minimumDistanceFromPlanetToMeteors) {
			Vector3 randomPosition = Random.insideUnitSphere * maximumDistanceFromPlanetToMeteors;
			meteorPosition.x = randomPosition.x;
			meteorPosition.y = randomPosition.y;
			meteorPosition.z = randomPosition.z;
		}
		
		GameObject newAsteroid = Instantiate(Resources.Load("Asteroid1"), meteorPosition, Random.rotation) as GameObject;
		
		float meteorSize = size;
		if (meteorSize == 0)
			meteorSize = Random.value * maxScalling;
		
		newAsteroid.transform.localScale += new Vector3(3, 3, 3);
		newAsteroid.transform.localScale += new Vector3(meteorSize,  meteorSize, meteorSize);
		newAsteroid.rigidbody.AddTorque(Random.insideUnitSphere * maxRotationForce);
		newAsteroid.rigidbody.AddForce(Random.insideUnitSphere * maxMeteorInitialForce);
		
		newAsteroid.GetComponent<CollisionDamageDealer>().damageToDeal = damageAmount;
		newAsteroid.GetComponent<CollisionDamageController>().health = damageAmount * 10;
	}
}
