using UnityEngine;
using System.Collections;
using BFB.Cache;

public class AppendPlayerName : MonoBehaviour
{
    public GUIText target;
    public string appendText;

    private void Start()
    {
        if (SessionCache.Cache.CurrentPlayer == null && SessionCache.Cache.PlayerProfileExists())
        {
            SessionCache.Cache.LoadCurrentPlayer();
        }
        if (target != null && SessionCache.Cache.CurrentPlayer != null)
        {
            if (target.text == null)
            {
                target.text = string.Empty;
            }
            target.text += SessionCache.Cache.CurrentPlayer.Name + appendText;
        }
    }
}
