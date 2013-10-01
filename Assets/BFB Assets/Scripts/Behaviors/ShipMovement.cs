using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BFB.Helpers;
using BFB.Cache;
using BFB.Models;
using System;

public class ShipMovement : MonoBehaviour
{
    public float moveForce = 1000f;
    public float rotateSpeed = 100f;
    public float fuelConsamptionToRotate = 5f;
    public float fuelConsamptionToAccelerate = 5f;

    public GameObject target;

    void Start()
    {
        if (target == null)
        {
            target = gameObject;
        }
        SetFlamesEnabled(false);
    }

    void Update()
    {
        // show menu if 'esc' key pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            target.GetComponent<GameMenu>().enabled = true;
            SessionCache.Cache.LevelInspector.currentState = LevelInspector.GameState.Pause;
        }

        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
		
		/// calculate fuel consumption.
		float dFluel = Math.Abs(hInput) * Time.deltaTime * fuelConsamptionToRotate;
		dFluel += Math.Abs(vInput) * Time.deltaTime * fuelConsamptionToAccelerate;
		
		if (dFluel <= SessionCache.Cache.CurrentPlayer.Ship.Fuel) {
			SessionCache.Cache.CurrentPlayer.Ship.Fuel -= dFluel;
	        target.transform.Rotate(0, hInput * rotateSpeed * Time.deltaTime, 0);
    	    //target.rigidbody.AddTorque (0, hInput * rotateForce, 0);
        	Vector3 forwardForce = target.transform.forward * moveForce * vInput;
        	target.rigidbody.AddForce(forwardForce, ForceMode.Force);
        	if (forwardForce.magnitude > 0)
        	{
	            SetFlamesEnabled(true);
        	}
		} else {
			Debug.Log("Not enough fuel for movement or/and rotation");	
		}
    }

    void OnTriggerEnter(Collider other)
    {
        /*Debug.Log("collided with " + other.tag);
		if (other.CompareTag(Tags.planet)) {
            GameMenu menu = target.GetComponent<GameMenu>();
            if (menu != null) 
            {
                menu.enabled = true;
            }
        	SessionCache.Cache.LevelInspector.currentState = LevelInspector.GameState.Destroyed;
        }
        else*/ if (other.CompareTag(Tags.winPoint))
        {
            GameMenu menu = target.GetComponent<GameMenu>();
            if (menu != null)
            {
                menu.enabled = true;
            }
			SessionCache.Cache.LevelInspector.NextLevel();
		}
    }

    public void SetFlamesEnabled(bool enabled)
    {
        //IList<GameObject> flameParticleSystems = new List<GameObject>();
        //IList<GameObject> flames = GameObject.FindGameObjectsWithTag (Tags.flame);
        //ParticleSystem particle = target.GetComponent (typeof(ParticleSystem)) as ParticleSystem;
        //GameObject particlesystem = flames[0];
        //if (particlesystem != null) {
        //	Debug.Log ("Here");
        //}
    }
}
