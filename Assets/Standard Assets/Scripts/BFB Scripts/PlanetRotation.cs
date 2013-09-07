using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour
{
	float rotateForce = 20f;
	
	void Start ()
	{
		gameObject.rigidbody.AddTorque (gameObject.transform.up * rotateForce, ForceMode.Force);
	}
	
	void Update ()
	{
	}
}
