using UnityEngine;
using System.Collections;
using BFB.Cache;

public class OpeningScript : MonoBehaviour
{
	
	float speed = 0.1f;
	bool crawling = false;
	bool part2 = false;
	string creds = "";
	private LevelInspector levelInspector = null;
	public GameObject Earth;
	public GameObject explosionPrefab;
	public Camera mainCam;
	
	// Use this for initialization
	void Start ()
	{		
		levelInspector = GlobalManagerInstance.GetLevelInspector ();
		
		crawling = true;
		creds += "In the distant future . . . \n";
		creds += " (well not really that distant)\n";
		creds += "Earth is visited by \n";
		creds += "extraterrestrial beings from \n";
		creds += "a galaxy far, far away. \n";
		creds += "The people of Earth welcome \n";
		creds += "these beings, hoping to learn\n";
		creds += "more about the universe. But \n";
		creds += "shortly after making first \n";
		creds += "contact with the aliens,\n";
		creds += "THIS happened\n";
		gameObject.guiText.text = creds;
	
	}
	
	// Update is called once per frame
	void Update ()
	{		
		MoveCam ();
		
		transform.Translate (Vector3.up * Time.deltaTime * speed);
		
		if (gameObject.transform.position.y > 2.25 && !part2) {
			ExplodeEarth ();
		}
		
		if (gameObject.transform.position.y > 2 && part2) {
			NextScene ();
		}
		
		if (part2)
			SaveHumanity ();			
	}
	
	void ExplodeEarth ()
	{
		crawling = false;
		Instantiate (explosionPrefab, Earth.transform.position, Earth.transform.rotation);
		Destroy (Earth);
		StartCoroutine (Timer (5.0f));
		part2 = true;
		transform.position = new Vector3 (0, -1, 0);
	}
	
	void NextScene ()
	{
		if (string.IsNullOrEmpty (SessionCache.Cache.CurrentPlayer.Name)) {
			levelInspector.LoadFirstLaunchMenu ();
		} else { 
			levelInspector.LoadBriefingMenu ();
		}
	}
	
	void SaveHumanity ()
	{
		crawling = true;
		creds = "Yea.. Well, against all odds, you managed \n";
		creds += "to escape before the detonation. \n\n";
		creds += "Now, with your team, you\n";
		creds += "must  navigate the universe in\n";
		creds += "search of a new place to call \n";
		creds += "home. The fate of humanity\n";
		creds += "depends on you . . .\n";
		creds += "so DO NOT screw it up.\n";
		gameObject.guiText.text = creds;
	}
	
	void MoveCam ()
	{
		if (mainCam.transform.position.z > -10) {
			mainCam.transform.Translate (Vector3.back * Time.deltaTime * speed);
		}
	}
	
	IEnumerator Timer (float duration)
	{
		yield return new WaitForSeconds(duration);			
	}
	
	private void OnGUI ()
	{
		if (GUI.Button (new Rect (50, 520, 100, 20), "Skip")) {
			NextScene();
		}
	}
}
