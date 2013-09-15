using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BFB.Models;

namespace BFB
{
	public class MetaCache
	{
		#region Singleton
		private MetaCache ()
		{
			LoadPlanetTypesCache();
			LoadSpaceshipTypesCache();
			LoadWeaponTypesCache();
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
		#endregion
		
		#region Planets
		private void LoadPlanetTypesCache()
		{
			//fill in planets list
			//fill in planets dictionary
		}
		
		public PlanetType GetPlanetType(Guid gId)
		{
			if (g_oPlanetTypesHashed.ContainsKey (gId))
			{
				return g_oPlanetTypesHashed[gId];
			} // else
			return null;
		}
		
		public IEnumerable<PlanetType> Planets { get { return g_oPlanetTypes; } }
		
		private static IList<PlanetType> g_oPlanetTypes = new List<PlanetType>();
		private static IDictionary<Guid, PlanetType> g_oPlanetTypesHashed = new Dictionary<Guid, PlanetType>();
		#endregion
		
		#region Spaceship Types
		private void LoadSpaceshipTypesCache()
		{
			
		}
		
		public SpaceshipType GetSpaceshipType(Guid gId)
		{
			if (g_oSpaceshipTypesHashed.ContainsKey (gId))
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
			
		}
		
		public WeaponType GetWeaponType(Guid gId)
		{
			if (g_oWeaponTypesHashed.ContainsKey (gId))
			{
				return g_oWeaponTypesHashed[gId];
			} // else
			return null;
		}
		
		public IEnumerable<WeaponType> WeaponType { get { return g_oWeaponTypes; } }
		
		private static IList<WeaponType> g_oWeaponTypes = new List<WeaponType>();
		private static IDictionary<Guid, WeaponType> g_oWeaponTypesHashed = new Dictionary<Guid, WeaponType>();
		#endregion
	}
	
	public class SessionCache
	{
		#region Singleton
		private SessionCache ()
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
		public Player CurrentPlayer 
		{
			get { return g_oCurrentPlayer; }
			set { g_oCurrentPlayer = value; }
		}
		
		private static Player g_oCurrentPlayer;
		#endregion
		
		#region Current Level
		public IList<Spaceship> Spaceships
		{ 
			get { return g_oSpaceships; }
		}
			
		private static IList<Spaceship> g_oSpaceships = new List<Spaceship>();
		
		
		public IList<Planet> Planets
		{ 
			get { return g_oPlanets; }
		}
			
		private static IList<Planet> g_oPlanets = new List<Planet>();
		#endregion
	}
}

