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
    public class MetaCache
    {
        #region Singleton
        private MetaCache()
        {
            Initialize();
        }

        public static MetaCache Cache
        {
            get
            {
                if (g_oCache == null)
                {
                    g_oCache = new MetaCache();
                }
                return g_oCache;
            }
            private set { g_oCache = value; }
        }

        private static MetaCache g_oCache;

        private void Initialize()
        {
            LoadSpaceshipTypesCache();
            LoadWeaponTypesCache();
            Debug.Log(string.Format("[Loaded]Spaceship Types: {0}, Weapon Types: {1}.", SpaceshipTypes.Count(), WeaponTypes.Count()));
        }

        public void Init()
        {
            //dummy method to trigger private initialize
        }
        #endregion

        #region Spaceship Types
        private void LoadSpaceshipTypesCache()
        {
            //clear old lists, just in case
            g_oSpaceshipTypes.Clear();
            g_oSpaceshipTypesHashed.Clear();

            //get fresh types from xml file
            XMLCollection<SpaceshipType> oTypes = SerializationHelper.LoadXMLDataFromFile<XMLCollection<SpaceshipType>>(SpaceshipTypesFile, null);
            if (oTypes != null && oTypes.Collection != null)
            {
                //add types to list and dictionary
                foreach (SpaceshipType oType in oTypes.Collection)
                {
                    g_oSpaceshipTypes.Add(oType);
                    g_oSpaceshipTypesHashed.Add(oType.Id, oType);
                }
            }
        }

        public SpaceshipType GetSpaceshipType(Guid gId)
        {
            if (g_oSpaceshipTypesHashed.ContainsKey(gId))
            {
                return g_oSpaceshipTypesHashed[gId];
            } // else
            return null;
        }

        public IEnumerable<SpaceshipType> SpaceshipTypes { get { return g_oSpaceshipTypes; } }

        private static IList<SpaceshipType> g_oSpaceshipTypes = new List<SpaceshipType>();
        private static IDictionary<Guid, SpaceshipType> g_oSpaceshipTypesHashed = new Dictionary<Guid, SpaceshipType>();
        #endregion

        #region Weapon Types
        private void LoadWeaponTypesCache()
        {
            //clear old lists, just in case
            g_oWeaponTypes.Clear();
            g_oWeaponTypesHashed.Clear();

            //get fresh types from xml file
            XMLCollection<WeaponType> oTypes = SerializationHelper.LoadXMLDataFromFile<XMLCollection<WeaponType>>(WeaponTypesFile, null);
            if (oTypes != null && oTypes.Collection != null)
            {
                //add types to list and dictionary
                foreach (WeaponType oType in oTypes.Collection)
                {
                    g_oWeaponTypes.Add(oType);
                    g_oWeaponTypesHashed.Add(oType.Id, oType);
                }
            }
        }

        public WeaponType GetWeaponType(Guid gId)
        {
            if (g_oWeaponTypesHashed.ContainsKey(gId))
            {
                return g_oWeaponTypesHashed[gId];
            } // else
            return null;
        }

        public IEnumerable<WeaponType> WeaponTypes { get { return g_oWeaponTypes; } }

        private static IList<WeaponType> g_oWeaponTypes = new List<WeaponType>();
        private static IDictionary<Guid, WeaponType> g_oWeaponTypesHashed = new Dictionary<Guid, WeaponType>();
        #endregion

        #region Serialization Helpers
        public string MetaDataPath { get { return g_sMetaDataPath; } }
        private static string g_sMetaDataPath = "gamedata/meta";

        public string SpaceshipTypesFile { get { return Path.Combine(MetaDataPath, g_sSpaceshipTypesFile); } }
        private static string g_sSpaceshipTypesFile = "spaceshiptypes.xml";

        public string WeaponTypesFile { get { return Path.Combine(MetaDataPath, g_sWeaponTypesFile); } }
        private static string g_sWeaponTypesFile = "weapontypes.xml";
        #endregion
    }

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

