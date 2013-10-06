﻿using UnityEngine;
using System.Collections;
using BFB.Models;
using BFB.Cache;
using System;

public class PlayerWrapper : MonoBehaviour
{
    #region Fields

    public GameObject spaceshipGameObject;
    private Player player;
    private Spaceship spaceship;

    #endregion

    #region Methods

    private void Start()
    {
        player = SessionCache.Cache.CurrentPlayer;
        spaceship = new Spaceship(player.ShipTypeId, spaceshipGameObject);
    }

    private void Update()
    {
        HandleShipMovement();
        HandlePlanetAttraction();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with " + other.tag);
        CollisionDamageDealer damageDealer = other.gameObject.GetComponent<CollisionDamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.damageToDeal);
            if (Health <= 0)
            {
                DestroyPlayer(other.gameObject);
                SendMessage("DestroyObject", other.gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void HandleShipMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        bool bFlamesEnabled = false;

        /// calculate fuel consumption.
        float dFuel = Math.Abs(vInput) * Time.deltaTime * FuelConsumptionToAccelerate;
        dFuel += Math.Abs(hInput) * Time.deltaTime * FuelConsumptionToRotate;

        if (Fuel > 0)
        {
            TakeFuel(dFuel);
            gameObject.transform.Rotate(0, hInput * RotationSpeed * Time.deltaTime, 0);
            Vector3 forwardForce = gameObject.transform.forward * AccelerationForce * vInput;
            gameObject.rigidbody.AddForce(forwardForce, ForceMode.Force);
            //flamesEnabled = forwardForce.magnitude > 0;
            bFlamesEnabled = true;
        }
        else
        {
            Debug.Log("Not enough fuel for movement or/and rotation");
        }

        SetFlamesEnabled(bFlamesEnabled);
    }

    private void HandlePlanetAttraction()
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
            gameObject.rigidbody.AddForce(direction * forceModule, ForceMode.Force);
        }
    }

    public void SetFlamesEnabled(bool bEnabled)
    {

    }

    public void TakeDamage(float fAmount)
    {
        spaceship.Health -= fAmount;
        if (spaceship.Health <= 0)
        {
            spaceship.Health = 0;
        }
    }

    public void TakeFuel(float fAmount)
    {
        spaceship.Fuel -= fAmount;
        if (spaceship.Fuel < 0)
        {
            spaceship.Fuel = 0;
        }
    }

    public void DestroyPlayer(GameObject collidedObject)
    {
        Destroy(gameObject);
        GlobalManagerInstance.GetLevelInspector().OnPlayerDestroyed();
    }

    #endregion

    #region Properties

    public string Name { get { return player.Name; } }

    public float Currency { get { return player.Currency; } }

    public float Fuel { get { return spaceship.Fuel; } }

    public float Health { get { return spaceship.Health; } }

    public float FuelConsumptionToAccelerate { get { return spaceship.Type.FuelConsumptionToAccelerate; } }

    public float FuelConsumptionToRotate { get { return spaceship.Type.FuelConsumptionToRotate; } }

    public float AccelerationForce { get { return spaceship.Type.AccelerationForce; } }

    public float RotationSpeed { get { return spaceship.Type.RotationSpeed; } }

    #endregion
}
