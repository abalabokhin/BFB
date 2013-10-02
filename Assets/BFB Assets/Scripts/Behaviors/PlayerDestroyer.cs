using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void DestroyObject(GameObject collidedObject) {
		Destroy(gameObject);
		GlobalManagerInstance.GetLevelInspector().OnPlayerDestroyed();
	}
}
