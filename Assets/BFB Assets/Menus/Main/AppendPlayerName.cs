using UnityEngine;
using System.Collections;
using BFB.Cache;

public class AppendPlayerName : MonoBehaviour
{
    public GUIText target;
    public string appendText;

    private void Start()
    {
        if (!string.IsNullOrEmpty(SessionCache.Cache.CurrentPlayer.Name))
        {
	        if (target != null)
	        {
	            if (target.text == null)
	            {
	                target.text = string.Empty;
	            }
	            target.text += SessionCache.Cache.CurrentPlayer.Name + appendText;
	        }
		}
    }
}
