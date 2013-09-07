using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAround : MonoBehaviour
{	
	IList<GameObject> planets = new List<GameObject>();
	float rotateForce = 1f;
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
		
		gameObject.rigidbody.AddTorque (gameObject.transform.up * rotateForce * hInput, ForceMode.Force);
		gameObject.rigidbody.AddForce (gameObject.transform.forward * moveForce * vInput, ForceMode.Force);
	}
}
