using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;
using System;

public class RegisterPlayerSpaceship : MonoBehaviour {	
	public string TypeId;
	
	// Use this for initialization
	void Start () {
		SessionCache.Cache.LoadCurrentPlayer(true);
		SessionCache.Cache.AssignPlayerShip(new Guid(TypeId), gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
