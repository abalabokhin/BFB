using UnityEngine;
using System.Collections;

public class AsteroidsGenerator : MonoBehaviour {
	public float minimumDistanceFromThePlayerToMeteors = 100;
	public float maximumDistanceFromThePlayerToMeteors = 500;
	/// time between next meteor generation.
	public float dtInSecs = 5;
	public float maxMeteorInitialForce = 50;
	public float maxScalling = 3;
	
	private float maxRotationForce = 3;
	float generatedAt = 0;
	
	GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		tryToGeneratenewAsteroid();
	}
	
	void tryToGeneratenewAsteroid() {
		if (generatedAt + dtInSecs > Time.time)
			return;
			
		generatedAt = Time.time;
		
		Vector3 playerPosition = player.transform.position;
		Vector3 meteorPosition = playerPosition;
		while ((meteorPosition - playerPosition).magnitude < minimumDistanceFromThePlayerToMeteors) {
			Vector2 randomPosition = Random.insideUnitCircle * maximumDistanceFromThePlayerToMeteors;
			meteorPosition.x = randomPosition.x;
			meteorPosition.x = 0;
			meteorPosition.x = randomPosition.y;
		}
		
		GameObject newAsteroid = Instantiate(Resources.Load("Asteroid1"), meteorPosition, Random.rotation) as GameObject;

		newAsteroid.rigidbody.AddTorque(Random.insideUnitSphere * maxRotationForce);
		newAsteroid.rigidbody.AddForce(Random.insideUnitSphere * maxMeteorInitialForce);
	}
}
