using UnityEngine;
using System.Collections;

public class MyUnitySingleton : MonoBehaviour
{
	private int playClicks= 0;
	private static MyUnitySingleton instance = null;

	public static MyUnitySingleton Instance {
		get { return instance; }
	}

	void Awake ()
	{
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
	
	private void MuteButton ()
	{
		if (GUI.Button (new Rect (50, 550, 100, 20), "Mute")) {
			playClicks++;
			AudioPlays (playClicks);
		}
	}
	
	private void AudioPlays (int hits)
	{
		if (hits % 2 == 0) {
			GetComponent<AudioSource> ().mute = false;
		}
		if (hits % 2 == 1) {
			GetComponent<AudioSource> ().mute = true;
		}
	}
	
	private void OnGUI ()
	{
		MuteButton();
	}
}
