using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
			get { return MetaCache.Cache.GetSpaceship(ShipId); } 
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private string m_sName;
		private Guid m_gShipId;
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
		
		public IEnumerable<Guid> WeaponIds 
		{ 
			get { return m_oSpaceshipIds; }
			set { m_oSpaceshipIds = value; }
		}
		
		public IEnumerable<SpaceshipWeapon> Weapons 
		{ 
			get 
			{
				if (m_oWeapons == null)
				{
					m_oWeapons = WeaponIds.Select(oItem => MetaCache.Cache.GetSpaceship(ShipId));
				}
				return m_oWeapons;
			}
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private IEnumerable<Guid> m_oSpaceshipIds = new List<Guid>();
		private IEnumerable<SpaceshipWeapon> m_oWeapons;
		#endregion
	}
	
	public class SpaceshipWeapon 
	{
		#region Properties
		public Guid Id { get; set; }
		#endregion
		
		#region Fields
		private Guid m_gId;
		#endregion
	}
	
	public class Planet
	{
		#region Properties
		public Guid Id { get; set; }
		#endregion
		
		#region Fields
		private Guid m_gId;
		#endregion
	}
}
