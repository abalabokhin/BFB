using UnityEngine;
using System.Collections;

public class GlobalManagerInstance : MonoBehaviour {
	public static GameObject GetManager()
    {
        if (g_oManager == null)
        {
			g_oManager = (GameObject)Instantiate(Resources.Load("GlobalManager"));
			DontDestroyOnLoad(g_oManager);
			Debug.Log("Global Manager was created");
        }
        return g_oManager;
    }
	
	public static LevelInspector GetLevelInspector() {
		return GetManager().GetComponent<LevelInspector>();
	}
	
    private static GameObject g_oManager = null;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
