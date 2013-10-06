using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;

public class AttractionToPlanets : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /// gravity force from all the planets.
        Vector3 position = transform.position;
        foreach (GameObject planet in GameObject.FindGameObjectsWithTag(Tags.planet))
        {
            Vector3 direction = planet.transform.position - position;
            float distance = direction.magnitude;
            direction.Normalize();
            float planetMass = planet.rigidbody.mass;
            float forceModule = Constants.gravityCoefficient * planetMass / (distance * distance);
            Debug.Log(distance);
            gameObject.rigidbody.AddForce(direction * forceModule, ForceMode.Force);
        }
    }
}
