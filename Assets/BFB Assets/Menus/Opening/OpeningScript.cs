using UnityEngine;
using System.Collections;
using BFB.Cache;

public class OpeningScript : MonoBehaviour
{
	
	float speed = 0.1f;
	bool crawling = false;
	bool part2 = false;
	string creds = "";
	public GameObject Earth;
	public GameObject explosionPrefab;
	
	// Use this for initialization
	void Start ()
	{		
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
		if (!crawling && part2)
			return;
		transform.Translate (Vector3.up * Time.deltaTime * speed);
		
		if (gameObject.transform.position.y > 2 && !part2) {
			crawling = false;
			explodeEarth ();
			StartCoroutine (ExplosionScene (5.0f));
			part2 = true;
			transform.position = new Vector3(0, -1, 0);
		}
		
		if (gameObject.transform.position.y > 3.75 && part2) {
			Application.LoadLevel("MainMenu");
		}
		
		if (part2)
			startSecondPart ();			
	}
	
	void explodeEarth ()
	{
		Instantiate (explosionPrefab, Earth.transform.position, Earth.transform.rotation);
		Destroy(Earth);
	}
	
	void startSecondPart ()
	{
		crawling = true;
		creds = "Against all odds, you managed \n";
		creds += "to escape before the detonation. \n\n\n";
		creds += "Now, with your team, you\n";
		creds += "must  navigate the universe in\n";
		creds += "search of a new place to call \n";
		creds += "home. The fate of humanity\n";
		creds += "depends on you . . .\n";
		creds += "so DO NOT screw it up.\n";
		gameObject.guiText.text = creds;
	}
	
	IEnumerator ExplosionScene (float duration)
	{
		yield return new WaitForSeconds(duration);			
	}
}
