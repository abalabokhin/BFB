using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour
{
	/// <summary>
	/// The mass of planet, set up from Unity GUI, we use it in gravity calculations.
	/// </summary> 
	public int mass;
	
	float rotateForce = 20f;
	
	void Start ()
	{
		gameObject.rigidbody.AddTorque (gameObject.transform.up * rotateForce, ForceMode.Force);
	}
	
	void Update ()
	{
	}
}
