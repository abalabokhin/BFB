using UnityEngine;
using System.Collections;
using BFB.Cache;
using BFB.Models;
using System;

public class RegisterPlanet : MonoBehaviour
{
    public string TypeId;

    // Use this for initialization
    void Start()
    {
        SessionCache.Cache.Planets.Add(new Planet(new Guid(TypeId), gameObject));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
