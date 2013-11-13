using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour
{
    public float rotateForce = 200f;

    void Start()
    {
        gameObject.rigidbody.AddTorque(gameObject.transform.up * rotateForce, ForceMode.Force);
    }

    void Update()
    {
    }
}
