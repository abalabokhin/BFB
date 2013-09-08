using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 offset = new Vector3 (0f, 2.5f, -5f);
	public float moveSpeed = 1;
	public float turnSpeed = 1;
	Vector3 goalPos;

	void Start ()
	{
		if (target == null) {
			target = GameObject.FindGameObjectWithTag (Tags.ship).transform;
		}
		if (target == null) {
			this.enabled = false;
		}
	}

	void FixedUpdate ()
	{
		goalPos = target.position + target.TransformDirection (offset);
		transform.position = Vector3.Lerp (transform.position, goalPos, Time.deltaTime * moveSpeed);
		transform.rotation = Quaternion.Lerp (transform.rotation, target.rotation, Time.deltaTime * moveSpeed);
	}
}

