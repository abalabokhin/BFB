using UnityEngine;
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
	private LevelInspector levelInspector;
	public GameObject boundary;

    #endregion

    #region Methods


	private void Start ()
	{
		player = SessionCache.Cache.CurrentPlayer;
		spaceship = new Spaceship (player.ShipTypeId, spaceshipGameObject);
		/// send message here to set up amount of health in other script. If we want to controll this parameter from this class, 
		/// we can add another message from damageController class.
		SendMessage ("setHealth", spaceship.Health, SendMessageOptions.DontRequireReceiver);

		levelInspector = GlobalManagerInstance.GetLevelInspector ();
	}

	private void Update ()
	{
		HandleShipMovement ();
		HandleShoot ();
	}

	private void HandleShoot ()
	{
		if (Input.GetMouseButtonDown (0)) {
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo)) {
				if (hitInfo.collider.tag == Tags.planet) {
					GameObject.Destroy (hitInfo.collider.gameObject);
				}
			}
		}
	}

	private void OnTriggerEnter (Collider other)
	{
		Debug.Log ("collided with " + other.tag);
		if (other.CompareTag (Tags.winPoint)) {
			WinLevel ();
		}
	}

	public void HandleShipMovement ()
	{
		float hInput = Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");

		bool bFlamesEnabled = false;

		/// calculate fuel consumption.
		float dFuel = Math.Abs (vInput) * Time.deltaTime * FuelConsumptionToAccelerate;
		dFuel += Math.Abs (hInput) * Time.deltaTime * FuelConsumptionToRotate;

		if (Fuel > 0) {
			TakeFuel (dFuel);
			bFlamesEnabled = true;
			//rotate
			gameObject.transform.Rotate (0, hInput * RotationSpeed * Time.deltaTime, 0);
			//accelerate
			Vector3 forwardForce = gameObject.transform.forward * AccelerationForce * vInput;
			gameObject.rigidbody.AddForce (forwardForce, ForceMode.Force);
		} else {
			Debug.Log ("Not enough fuel for movement or/and rotation");
		}

		//flamesEnabled = forwardForce.magnitude > 0;
		SetFlamesEnabled (bFlamesEnabled);
	}

	private void WinLevel ()
	{
		Debug.Log ("Winpoint reached");
		GameMenu menu = gameObject.GetComponent<GameMenu> ();
		if (menu != null) {
			menu.enabled = true;
		}
		levelInspector.NextLevel ();
	}

	public void SetFlamesEnabled (bool bEnabled)
	{
		//IList<GameObject> flameParticleSystems = new List<GameObject>();
		//IList<GameObject> flames = GameObject.FindGameObjectsWithTag (Tags.flame);
		//ParticleSystem particle = target.GetComponent (typeof(ParticleSystem)) as ParticleSystem;
		//GameObject particlesystem = flames[0];
		//if (particlesystem != null) {
		//	Debug.Log ("Here");
		//}
	}

	public void TakeFuel (float fAmount)
	{
		spaceship.Fuel -= fAmount;
		if (spaceship.Fuel < 0) {
			spaceship.Fuel = 0;
		}
	}
	

    #endregion

    #region Properties

	public string Name { get { return player.Name; } }

	public float Currency { get { return player.Currency; } }

	public float Fuel { get { return spaceship.Fuel; } }

	//public float Health { get { return spaceship.Health; } }

	public float FuelConsumptionToAccelerate { get { return spaceship.Type.FuelConsumptionToAccelerate; } }

	public float FuelConsumptionToRotate { get { return spaceship.Type.FuelConsumptionToRotate; } }

	public float AccelerationForce { get { return spaceship.Type.AccelerationForce; } }

	public float RotationSpeed { get { return spaceship.Type.RotationSpeed; } }

    #endregion
}
