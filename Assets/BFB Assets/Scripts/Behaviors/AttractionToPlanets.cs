using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;

public class AttractionToPlanets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/// gravity force from all the planets.
        Vector3 position = transform.position;
	    foreach (Planet planet in SessionCache.Cache.Planets)
        {
            GameObject planetObject = planet.GameObject;
            if (planetObject != null)
            {
                Vector3 direction = planetObject.transform.position - position;
                float distance = direction.magnitude;
                direction.Normalize();
                float planetMass = planetObject.GetComponent<PlanetBehaviour>().mass;
                float forceModule = Constants.gravityCoefficient * planetMass / (distance * distance);
                gameObject.rigidbody.AddForce(direction * forceModule, ForceMode.Force);
            }
        }           
	}
}
