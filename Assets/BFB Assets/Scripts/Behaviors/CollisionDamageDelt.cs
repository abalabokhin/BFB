using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;

public class CollisionDamageDelt : MonoBehaviour {
	
	public float health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with " + other.tag);
		CollisionDamageDealer damageDealer = other.gameObject.GetComponent<CollisionDamageDealer>();
		if (damageDealer != null) {
			health -= damageDealer.damageToDeal;
			Debug.Log("object can deal damage " + damageDealer.damageToDeal + " health left " + health);
			if (health <= 0) {
				// send messge here. Every object that do different things when it should be destroyed (play animation, create other objects, etc). 
				// So it is better to use another script with the method "Destroy Object". To create your own objects death response, just create a 
				// script that has this method. Also I send the object that cause the deadly damage in the message, we might need it to play 
				// different animation for instance.
				SendMessage ("DestroyObject", other.gameObject, SendMessageOptions.DontRequireReceiver);
			}
		}
    }
}
