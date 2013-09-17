using UnityEngine;
using System.Collections;
using System;
using BFB.Cache;
using BFB.Models;

public class RegisterSpaceship : MonoBehaviour
{
    public string TypeId;

    // Use this for initialization
    void Start()
    {
        SessionCache.Cache.Spaceships.Add(new Spaceship(new Guid(TypeId), gameObject));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
