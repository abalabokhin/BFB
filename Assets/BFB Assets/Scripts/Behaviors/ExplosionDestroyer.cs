using UnityEngine;
using System.Collections;

public class ExplosionDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void DestroyObject(GameObject collidedObject)
    {
		/// make asteroid invisible
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
		gameObject.GetComponent<Detonator>().enabled = true;
        Destroy(gameObject, 2f);
    }
}
