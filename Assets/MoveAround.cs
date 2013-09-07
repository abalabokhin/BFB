using UnityEngine;
using System.Collections;

public class MoveAround : MonoBehaviour
{	
	float rotateForce = 1f;
	float moveForce = 3f;
	
	void Start ()
	{
	}
	
	void Update ()
	{
		float hInput = Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");
		
		if (hInput > 0 || vInput > 0) 
		{
			Debug.Log (string.Format ("hInput: {0}\nvInput: {1}", hInput, vInput));
		}
		
		gameObject.rigidbody.AddTorque (gameObject.transform.up * rotateForce * hInput, ForceMode.Force);
		gameObject.rigidbody.AddForce (gameObject.transform.forward * moveForce * vInput, ForceMode.Force);
	}
}
