using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BFB.Helpers;
using BFB.Cache;

namespace BFB.Models
{
	public class Player
	{
		#region Properties
		public Guid Id 
		{ 
			get { return m_gId; }
			set { m_gId = value; }
		}
		
		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}
		
		public Guid ShipId 
		{ 
			get { return m_gShipId; }
			set { m_gShipId = value; }
		}
		
		public Spaceship Ship 
		{ 
			get { return null; } // MetaCache.Cache.GetSpaceshipType(ShipId); } 
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private string m_sName;
		private Guid m_gShipId;
		#endregion
	}
	
	public class SpaceshipType
	{
		#region Properties
		public Guid Id 
		{ 
			get { return m_gId; }
			set { m_gId = value; }
		}
		
		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private string m_sName;
		#endregion
	}
	
	public class Spaceship
	{
		#region Properties
		public Guid Id 
		{ 
			get { return m_gId; }
			set { m_gId = value; }
		}
		
		public Guid TypeId 
		{ 
			get { return m_gTypeId; }
			set { m_gTypeId = value; }
		}
		
		public SpaceshipType Type { get { return MetaCache.Cache.GetSpaceshipType(TypeId); } }
		
		public IEnumerable<Guid> WeaponIds 
		{ 
			get { return m_oWeaponIds; }
			set { m_oWeaponIds = value; }
		}
		
		public IEnumerable<Weapon> Weapons 
		{ 
			get 
			{
				if (m_oWeapons == null)
				{
					m_oWeapons = new List<Weapon>();
				}
				return m_oWeapons;
			}
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private Guid m_gTypeId;
		private IEnumerable<Guid> m_oWeaponIds = new List<Guid>();
		private IEnumerable<Weapon> m_oWeapons;
		#endregion
	}
	
	public class WeaponType
	{
		#region Properties
		public Guid Id 
		{ 
			get { return m_gId; }
			set { m_gId = value; }
		}
		
		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private string m_sName;
		#endregion
	}
	
	public class Weapon 
	{
		#region Properties
		public Guid Id 
		{ 
			get { return m_gId; }
			set { m_gId = value; }
		}
				
		public Guid TypeId 
		{ 
			get { return m_gTypeId; }
			set { m_gTypeId = value; }
		}
		
		public WeaponType Type { get { return MetaCache.Cache.GetWeaponType(TypeId); } }
		#endregion
		
		#region Fields
		private Guid m_gId;
		private Guid m_gTypeId;
		#endregion
	}
	
	public class PlanetType
	{
		#region Properties
		public Guid Id 
		{ 
			get { return m_gId; }
			set { m_gId = value; }
		}
		
		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private string m_sName;
		#endregion
	}
	
	public class Planet
	{
		#region Properties
		public Guid Id 
		{ 
			get { return m_gId; }
			set { m_gId = value; }
		}
				
		public Guid TypeId 
		{ 
			get { return m_gTypeId; }
			set { m_gTypeId = value; }
		}
		
		public PlanetType Type { get { return MetaCache.Cache.GetPlanetType(TypeId); } }
		#endregion
		
		#region Fields
		private Guid m_gId;
		private Guid m_gTypeId;
		#endregion
	}
}
