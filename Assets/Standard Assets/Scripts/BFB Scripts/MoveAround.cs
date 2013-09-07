using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAround : MonoBehaviour
{	
	IList<GameObject> planets = new List<GameObject>();
	//float rotateForce = 1f;
	float rotateSpeed = 3f;
	float moveForce = 3f;
	
	void Start ()
	{
		planets.Clear();
		planets.AddRange(GameObject.FindGameObjectsWithTag(Tags.planet));
		Debug.Log (string.Format ("Found {0} planets!", planets.Count));
	}
	
	void Update ()
	{
		float hInput = Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");
	
		gameObject.transform.Rotate(0, hInput * rotateSpeed, 0);
		
		//gameObject.rigidbody.AddTorque (gameObject.transform.up * rotateForce * hInput, ForceMode.Force);
		gameObject.rigidbody.AddForce (gameObject.transform.forward * moveForce * vInput, ForceMode.Force);
		
	
		/// gravity force from all the planets.
		Vector3 position = transform.position; 
	
		foreach (GameObject planet in planets) {
			Vector3 direction = (planet.transform.position - position);
			var distance = direction.magnitude; 
			float planetMass = planet.GetComponent<Rigidbody>().mass;
			float forceModule = Constants.gravityCoefficient * planetMass / (distance * distance);
			gameObject.rigidbody.AddForce (direction * forceModule, ForceMode.Force);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("collided");
	}
}
