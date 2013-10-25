using UnityEngine;
using System.Collections;

public class ReducePlanetPopulation : MonoBehaviour {
	public int peopleAlive = 5000000;
	public int dPeopleDead = 500000;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI() {
		float stdW = 320;
		float stdH = 30;
		float currX = 10;
		float currY = 10;
		
		GUI.Label (new Rect (currX, currY, stdW, stdH), string.Format("People Alive: {0}", peopleAlive));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnTriggerEnter(Collider other)
    {
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == BFB.Cache.Tags.asteroid) {
			peopleAlive -= dPeopleDead;
		}
		if (peopleAlive <= 0) {
			GlobalManagerInstance.GetLevelInspector().OnPlayerDestroyed();
		}
    }
}
