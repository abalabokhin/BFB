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

        public float MaxHealth
        {
            get { return m_fMaxHealth; }
            set { m_fMaxHealth = value; }
        }

        public float MaxFuel
        {
            get { return m_fMaxFuel; }
            set { m_fMaxFuel = value; }
        }

        public float FuelConsumptionToAccelerate
        {
            get { return m_fFuelConsumptionToAccelerate; }
            set { m_fFuelConsumptionToAccelerate = value; }
        }

        public float FuelConsumptionToRotate
        {
            get { return m_fFuelConsumptionToRotate; }
            set { m_fFuelConsumptionToRotate = value; }
        }

        public float AccelerationForce
        {
            get { return m_fAccelerationForce; }
            set { m_fAccelerationForce = value; }
        }

        public float RotationSpeed
        {
            get { return m_fRotationSpeed; }
            set { m_fRotationSpeed = value; }
        }
        #endregion

        #region Fields
        private Guid m_gId;
        private string m_sName;
        private float m_fMaxHealth;
        private float m_fMaxFuel;
        private float m_fFuelConsumptionToAccelerate;
        private float m_fFuelConsumptionToRotate;
        private float m_fAccelerationForce = 1000f;
        private float m_fRotationSpeed = 100f;
        #endregion
    }

    public class Spaceship
    {
        #region Constructors
        public Spaceship()
        {
            Id = new Guid();
        }

        public Spaceship(Guid gTypeId, GameObject oGameObject)
            : base()
        {
            TypeId = gTypeId;
            GameObject = oGameObject;

            //set up initial values based on type
            Health = Type.MaxHealth;
            Fuel = Type.MaxFuel;
        }
        #endregion

        #region Methods
        public void ResetParameters()
        {
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

        public float Health
        {
            get { return m_iHealth; }
            set { m_iHealth = value; }
        }

        public float Fuel
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
        private float m_iHealth;
        private float m_iFuel;
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
}
