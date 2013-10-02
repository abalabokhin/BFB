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
	public float fuel = 100f;

    public GameObject target;
	private LevelInspector levelInspector = null;

    void Start()
    {
		levelInspector = GlobalManagerInstance.GetLevelInspector();

        if (target == null)
        {
            target = gameObject;
        }
        SetFlamesEnabled(false);
    }

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
		
		/// calculate fuel consumption.
		float dFluel = Math.Abs(hInput) * Time.deltaTime * fuelConsamptionToRotate;
		dFluel += Math.Abs(vInput) * Time.deltaTime * fuelConsamptionToAccelerate;
		
		if (dFluel <= fuel) {
			fuel -= dFluel;
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
		if (other.CompareTag(Tags.winPoint))
        {
			Debug.Log("Winpoint reached");
            GameMenu menu = target.GetComponent<GameMenu>();
            if (menu != null)
            {
                menu.enabled = true;
            }
			levelInspector.NextLevel();
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
