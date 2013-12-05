using UnityEngine;
using System.Collections;

public class ExplosionDestroyer : MonoBehaviour {
	
	public AudioClip explosionSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void DestroyObject(GameObject collidedObject)
    {
		/// make asteroid invisible
		Destroy(gameObject, 2f);
		MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
		if (renderer == null)
			renderer = gameObject.GetComponentInChildren<MeshRenderer>();
		if (renderer != null)
			renderer.enabled = false;
		audio.PlayOneShot(explosionSound);
		gameObject.GetComponent<Detonator>().enabled = true;
    }
}
