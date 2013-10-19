using UnityEngine;
using System.Collections;

public class CollisionWithBoundary : MonoBehaviour
{
	
	//public GameObject player;
	public GameObject boundary;
	//public BoxCollider boundS;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		KeepInBounds ();
	}
	
	void KeepInBounds ()
	{
		Debug.Log("Velocity: " + rigidbody.velocity);
		float playerX, playerZ, boundaryX1, boundaryX2, boundaryZ1, boundaryZ2;
		BoxCollider box = boundary.GetComponent<BoxCollider> ();
		playerX = transform.position.x;
		boundaryX1 = boundary.transform.position.x + (box.size.x / 2);
		boundaryX2 = boundary.transform.position.x - (box.size.x / 2);
		playerZ = transform.position.z;
		boundaryZ1 = boundary.transform.position.z + (box.size.z / 2);
		boundaryZ2 = boundary.transform.position.z - (box.size.z / 2);
		
		if (playerX >= boundaryX1 || playerX <= boundaryX2 || playerZ >= boundaryZ1 || playerZ <= boundaryZ2) {
			Debug.Log ("Out of bounds");
			transform.Rotate (0, 20 * Time.deltaTime, 0);
			//rigidbody.velocity = Vector3.zero;
			GetComponent<PlayerWrapper> ().TakeFuel (0);
		} else {
			Debug.Log ("In bounds");
			GetComponent<PlayerWrapper> ().HandleShipMovement ();
		}
	}
	
	void OnTriggerExit (Collider colliInfo)
	{
		if (colliInfo.gameObject.tag == "Boundary") {
			//transform.Translate(boundary.transform.position.x,0,0);
		}
	}
}
