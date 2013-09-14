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
			LoadPlanetCache();
			LoadSpaceshipCache();
			LoadSpaceshipWeaponsCache();
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
		private void LoadPlanetCache()
		{
			//fill in planets list
			//fill in planets dictionary
		}
		
		public Planet GetPlanet(Guid gId)
		{
			if (g_oPlanetsHashed.ContainsKey (gId))
			{
				return g_oPlanetsHashed[gId];
			} // else
			return null;
		}
		
		public IEnumerable<Planet> Planets { get { return g_oPlanets; } }
		
		private static IList<Planet> g_oPlanets = new List<Planet>();
		private static IDictionary<Guid, Planet> g_oPlanetsHashed = new Dictionary<Guid, Planet>();
		#endregion
		
		#region Spaceships
		private void LoadSpaceshipCache()
		{
			
		}
		
		public Spaceship GetSpaceship(Guid gId)
		{
			if (g_oSpaceships.ContainsKey (gId))
			{
				return g_oSpaceships[gId];
			} // else
			return null;
		}
		
		public IEnumerable<Spaceship> Spaceships { get { return g_oSpaceships; } }
		
		private static IList<Spaceship> g_oSpaceships = new List<Spaceship>();
		private static IDictionary<Guid, Spaceship> g_oSpaceshipsHashed = new Dictionary<Guid, Spaceship>();
		#endregion
		
		#region Spaceship Weapons
		private void LoadSpaceshipWeaponsCache()
		{
			
		}
		
		public SpaceshipWeapons GetSpaceshipWeapon(Guid gId)
		{
			if (g_oSpaceshipWeaponsHashed.ContainsKey (gId))
			{
				return g_oSpaceshipWeaponsHashed[gId];
			} // else
			return null;
		}
		
		public IEnumerable<SpaceshipWeapon> SpaceshipWeapons { get { return g_oSpaceshipWeapons; } }
		
		private static IList<SpaceshipWeapon> g_oSpaceshipWeapons = new List<SpaceshipWeapon>();
		private static IDictionary<Guid, SpaceshipWeapon> g_oSpaceshipWeaponsHashed = new Dictionary<Guid, SpaceshipWeapon>();
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
	}
}

