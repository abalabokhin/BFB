using UnityEngine;
using System.Collections;

public class SmoothLookAt : MonoBehaviour
{
	Transform target;
	float damping = 6.0f;
	bool smooth = true;
	
	// Use this for initialization
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody != null) {
			rigidbody.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target != null) {
			if (smooth == true) {
				// Look at and dampen the rotation
				var rotation = Quaternion.LookRotation (target.position - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			} else {
				// Just lookat
				transform.LookAt (target);
			}
		}
	}
}

