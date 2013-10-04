using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;
using System;

public class RegisterPlanet : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        SessionCache.Cache.Planets.Add(new Planet(gameObject));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
