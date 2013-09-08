using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMovement : MonoBehaviour
{	
	IList<GameObject> planets = new List<GameObject> ();
	float rotateSpeed = 0.3f;
	float moveForce = 50f;
	
	void Start ()
	{
		SetFlamesEnabled(false);
		planets.Clear ();
		planets.AddRange (GameObject.FindGameObjectsWithTag (Tags.planet));
		Debug.Log (string.Format ("Found {0} planets!", planets.Count));
	}
	
	void Update ()
	{
		float hInput = Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");
	
		gameObject.transform.Rotate (0, hInput * rotateSpeed, 0);
		
		//gameObject.rigidbody.AddTorque (gameObject.transform.up * rotateForce * hInput, ForceMode.Force);
		Vector3 forwardForce = gameObject.transform.forward * moveForce * vInput;
		gameObject.rigidbody.AddForce (forwardForce, ForceMode.Force);
		if (forwardForce.magnitude > 0) {
//			Debug.Log (string.Format ("Added forward force of {0} to ship.", forwardForce));
			SetFlamesEnabled(true);
		}
	
		/// gravity force from all the planets.
		Vector3 position = transform.position; 
	
		foreach (GameObject planet in planets) {
			Vector3 direction = planet.transform.position - position;
			float distance = direction.magnitude;
			Vector3 direction = (planet.transform.position - position);
			direction.Normalize();
			var distance = direction.magnitude; 
			float planetMass = planet.rigidbody.mass;
			float forceModule = Constants.gravityCoefficient * planetMass / (distance * distance);
			gameObject.rigidbody.AddForce (direction * forceModule, ForceMode.Force);
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("collided");
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void SetFlamesEnabled (bool enabled)
	{
		//IList<GameObject> flameParticleSystems = new List<GameObject>();
		//IList<GameObject> flames = GameObject.FindGameObjectsWithTag (Tags.flame);
		//ParticleSystem particle = gameObject.GetComponent (typeof(ParticleSystem)) as ParticleSystem;
		//GameObject particlesystem = flames[0];
		//if (particlesystem != null) {
		//	Debug.Log ("Here");
		//}
	}
}
