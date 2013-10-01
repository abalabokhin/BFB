using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;

public class CollisionResponse : MonoBehaviour {

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
			SessionCache.Cache.CurrentPlayer.Ship.Health -= damageDealer.damageToDeal;
			Debug.Log("object can deal damage " + damageDealer.damageToDeal + " health left " + SessionCache.Cache.CurrentPlayer.Ship.Health);
			if (SessionCache.Cache.CurrentPlayer.Ship.Health <= 0) {
				// object destroyed
				GameMenu menu = gameObject.GetComponent<GameMenu>();
            	if (menu != null) 
            	{
                	menu.enabled = true;
            	}
        		SessionCache.Cache.LevelInspector.currentState = LevelInspector.GameState.Destroyed;
			}
		}
    }
}
