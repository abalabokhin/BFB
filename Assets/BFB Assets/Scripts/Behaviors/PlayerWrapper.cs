using UnityEngine;
using System.Collections;
using BFB.Models;
using BFB.Cache;
using System;

public class PlayerWrapper : MonoBehaviour
{
    #region Fields

	public GameObject spaceshipGameObject;
	public float lookSpeed = 300;
	private Player player;
	private Spaceship spaceship;
	private LevelInspector levelInspector;
	//public GameObject boundary;
	private bool useAlternativeControls = false;
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
	
	private void OnGUI ()
	{
		if (useAlternativeControls)
			GUI.Box (new Rect (Screen.width / 2 - 10, Screen.height / 2 - 10, 20, 20), "O");
	}
	
	private void HandleShoot ()
	{
		
		if (Input.GetMouseButtonDown (0)) {
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Debug.Log(Input.mousePosition);
			if (useAlternativeControls)
				ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo)) {
				Debug.Log ("clicked on " + hitInfo.collider.tag);
				if (hitInfo.collider.tag == Tags.asteroid) {
					hitInfo.collider.gameObject.SendMessage("DestroyObject", gameObject, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.tag != Tags.boundary) {
			Debug.Log ("collided with " + other.tag);
		}
		if (other.CompareTag (Tags.winPoint)) {
			WinLevel ();
		}
	}

	public void HandleShipMovement ()
	{
		float hInput = Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");

		bool bFlamesEnabled = false;
		float dFuel = 0;
		
		/*int upDownDirection = 0;
		if (Input.GetKey (KeyCode.R)) {
			upDownDirection = 1; 
		}
		if (Input.GetKey (KeyCode.F)) {
			upDownDirection = -1; 
		}

		/// calculate fuel consumption.
		dFuel += Math.Abs (vInput) * Time.deltaTime * FuelConsumptionToAccelerate;
		dFuel += Math.Abs (upDownDirection) * Time.deltaTime * FuelConsumptionToRotate;
		dFuel += Math.Abs (hInput) * Time.deltaTime * FuelConsumptionToRotate;

		if (Fuel > 0) {
			TakeFuel (dFuel);
			//rotate
			transform.Rotate (transform.up, hInput * RotationSpeed * Time.deltaTime, Space.World);
			transform.Rotate (transform.right, upDownDirection * RotationSpeed * Time.deltaTime, Space.World);
			//accelerate
			Vector3 forwardForce = gameObject.transform.forward * AccelerationForce * vInput;
			gameObject.rigidbody.AddForce (forwardForce, ForceMode.Force);
		}*/
		
		
		useAlternativeControls = true;
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		
		dFuel += Math.Abs (vInput) * Time.deltaTime * FuelConsumptionToAccelerate;
		dFuel += Math.Abs (hInput) * Time.deltaTime * FuelConsumptionToAccelerate;
		dFuel += Math.Abs (mouseX) * Time.deltaTime * FuelConsumptionToRotate;
		dFuel += Math.Abs (mouseY) * Time.deltaTime * FuelConsumptionToRotate;
		
		if (Fuel > 0) {
			TakeFuel (dFuel);
			transform.Rotate (transform.up, lookSpeed * Time.deltaTime * Input.GetAxis ("Mouse X"), Space.World);
			transform.Rotate (transform.right, -lookSpeed * Time.deltaTime * Input.GetAxis ("Mouse Y"), Space.World);
			Vector3 forwardForce = gameObject.transform.forward * AccelerationForce * vInput;
			Vector3 rightForce = gameObject.transform.right * AccelerationForce * hInput;
		
			gameObject.rigidbody.AddForce (forwardForce, ForceMode.Force);
			gameObject.rigidbody.AddForce (rightForce, ForceMode.Force);
		}

		if (dFuel > 0)
			bFlamesEnabled = true;
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
