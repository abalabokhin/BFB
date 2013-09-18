using UnityEngine;
using System.Collections;
using BFB.Cache;

public class AttachShipToPlayer : MonoBehaviour {
	
	

	// Use this for initialization
	void Start () {
		if (SessionCache.Cache.CurrentPlayer != null && SessionCache.Cache.Spaceships.Count > 0) {
			SessionCache.Cache.CurrentPlayer.ShipId = SessionCache.Cache.Spaceships[0].Id;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
