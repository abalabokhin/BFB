using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using BFB.Models;
using BFB.Helpers;
using UnityEngine;

namespace BFB.Cache
{
    public class SessionCache
    {
        #region Singleton
        private SessionCache()
        {
        }

        public static SessionCache Cache
        {
            get
            {
                if (g_oCache == null)
                {
                    g_oCache = new SessionCache();
                }
                return g_oCache;
            }
            private set { g_oCache = value; }
        }

        private static SessionCache g_oCache;
        #endregion

        #region Player
        private void LoadCurrentPlayer()
        {
            g_oCurrentPlayer = new Player();
            CurrentPlayer.Load();
        }

        public Player CurrentPlayer
        {
            get
            {
                if (g_oCurrentPlayer == null)
                {
                    LoadCurrentPlayer();
                }
                return g_oCurrentPlayer;
            }
        }

        private static Player g_oCurrentPlayer;
        #endregion
    }
}

