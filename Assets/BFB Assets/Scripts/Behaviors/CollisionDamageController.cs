﻿using UnityEngine;
using System.Collections;

public class CollisionDamageController : MonoBehaviour {
	public float health = 50;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void setHealth(float newHealth) {
		health = newHealth;
	}
	
	private void OnTriggerEnter(Collider other)
    {
		CollisionDamageDealer damageDealer = other.gameObject.GetComponent<CollisionDamageDealer>();
        if (damageDealer != null)
        {
			dealDamage(damageDealer.damageToDeal);
        }
    }
	
	private void dealDamage(int damage) {
	    health -= damage;
        if (health <= 0)
        {
            SendMessage("DestroyObject", gameObject, SendMessageOptions.DontRequireReceiver);
        }
	}
}
