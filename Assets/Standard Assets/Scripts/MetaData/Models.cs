using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BFB.Helpers;
using BFB.Cache;
using System.Xml.Serialization;

namespace BFB.Models
{
	public class Player
    {
        #region Constructors
        public Player() { }
        #endregion

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
			get
            {
                if (m_oSpaceship == null || m_oSpaceship.Id != ShipId)
                {
                    m_oSpaceship = SessionCache.Cache.Spaceships.FirstOrDefault(oItem => oItem.Id == ShipId);
                }
                return m_oSpaceship;
            }
		}
		#endregion
		
		#region Fields
		private Guid m_gId;
		private string m_sName;
		private Guid m_gShipId;
        private Spaceship m_oSpaceship;
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

        public int MaxHealth
        {
            get { return m_iMaxHealth; }
            set { m_iMaxHealth = value; }
        }

        public int MaxFuel
        {
            get { return m_iMaxFuel; }
            set { m_iMaxFuel = value; }
        }
		#endregion
		
		#region Fields
		private Guid m_gId;
		private string m_sName;
        private int m_iMaxHealth;
        private int m_iMaxFuel;
		#endregion
	}
	
	public class Spaceship
    {
        #region Constructors
        public Spaceship() { }

        public Spaceship(Guid gTypeId, GameObject oGameObject)
        {
            Id = new Guid();
            TypeId = gTypeId;
            GameObject = oGameObject;

            //set up initial values based on type
            Health = Type.MaxHealth;
            Fuel = Type.MaxFuel;
        }
        #endregion

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

        public int Health
        {
            get { return m_iHealth; }
            set { m_iHealth = value; }
        }

        public int Fuel
        {
            get { return m_iFuel; }
            set { m_iFuel = value; }
        }
		
        [XmlIgnore]
		public SpaceshipType Type { get { return MetaCache.Cache.GetSpaceshipType(TypeId); } }

        [XmlIgnore]
        public GameObject GameObject
        {
            get { return m_oGameObject; }
            set { m_oGameObject = value; }
        }
		
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
        private GameObject m_oGameObject;
        private int m_iHealth;
        private int m_iFuel;
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
        #region Constructors
        public Weapon() { }

        public Weapon(Guid gTypeId, GameObject oGameObject)
        {
            Id = new Guid();
            TypeId = gTypeId;
            GameObject = oGameObject;
        }
        #endregion

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

        [XmlIgnore]
        public WeaponType Type { get { return MetaCache.Cache.GetWeaponType(TypeId); } }

        [XmlIgnore]
        public GameObject GameObject
        {
            get { return m_oGameObject; }
            set { m_oGameObject = value; }
        }
		#endregion
		
		#region Fields
		private Guid m_gId;
		private Guid m_gTypeId;
        private GameObject m_oGameObject;
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
        #region Constructors
        public Planet() { }

        public Planet(Guid gTypeId, GameObject oGameObject)
        {
            Id = new Guid();
            TypeId = gTypeId;
            GameObject = oGameObject;
        }
        #endregion

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

        [XmlIgnore]
        public PlanetType Type { get { return MetaCache.Cache.GetPlanetType(TypeId); } }

        [XmlIgnore]
        public GameObject GameObject
        {
            get { return m_oGameObject; }
            set { m_oGameObject = value; }
        }
		#endregion
		
		#region Fields
		private Guid m_gId;
        private Guid m_gTypeId;
        private GameObject m_oGameObject;
		#endregion
	}
}
