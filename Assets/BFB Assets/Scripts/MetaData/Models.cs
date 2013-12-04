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

        public Player()
        {
        }

        public Player(string sName)
        {
            m_sName = sName;
        }

        #endregion

        #region Methods

        public void Load()
        {
            m_sName = PlayerPrefs.GetString("Player.Name");
            m_fCurrency = PlayerPrefs.GetFloat("Player.Currency");
            m_iCurrentLevel = PlayerPrefs.GetInt("Player.CurrentLevel");
        }

        public void Save()
        {
            PlayerPrefs.SetString("Player.Name", m_sName);
            PlayerPrefs.SetFloat("Player.Currency", m_fCurrency);
            PlayerPrefs.SetInt("Player.CurrentLevel", m_iCurrentLevel);
        }

        #endregion

        #region Properties

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public float Currency
        {
            get { return m_fCurrency; }
            set { m_fCurrency = value; }
        }

        public int CurrentLevel
        {
            get { return m_iCurrentLevel; }
            set { m_iCurrentLevel = value; }
        }

        #endregion

        #region Fields

        private string m_sName;
        private float m_fCurrency;
        private int m_iCurrentLevel;

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
        private string m_sName = "Fighter";
        private float m_fMaxHealth = 500f;
        private float m_fMaxFuel = 300f;
        private float m_fFuelConsumptionToAccelerate = 5f;
        private float m_fFuelConsumptionToRotate = 5f;
        private float m_fAccelerationForce = 100f;
        private float m_fRotationSpeed = 80f;
        #endregion
    }

    public class Spaceship
    {
        #region Constructors
        public Spaceship()
        {
            Id = new Guid();
        }

        public Spaceship(SpaceshipType oType, GameObject oGameObject)
            : base()
        {
            m_oType = oType;
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
        public SpaceshipType Type { get { return m_oType; } }

        [XmlIgnore]
        public GameObject GameObject
        {
            get { return m_oGameObject; }
            set { m_oGameObject = value; }
        }

        public IEnumerable<Weapon> WeaponIds
        {
            get { return m_oWeapons; }
            set { m_oWeapons = value; }
        }
        #endregion

        #region Fields
        private Guid m_gId;
        private SpaceshipType m_oType;
        private IEnumerable<Weapon> m_oWeapons;
        private GameObject m_oGameObject;
        private float m_iHealth;
        private float m_iFuel;
        #endregion
    }

    public class Weapon
    {
        #region Constructors
        public Weapon() { }

        public Weapon(GameObject oGameObject)
        {
            Id = new Guid();
            GameObject = oGameObject;
        }
        #endregion

        #region Properties
        public Guid Id
        {
            get { return m_gId; }
            set { m_gId = value; }
        }

        [XmlIgnore]
        public GameObject GameObject
        {
            get { return m_oGameObject; }
            set { m_oGameObject = value; }
        }
        #endregion

        #region Fields
        private Guid m_gId;
        private GameObject m_oGameObject;
        #endregion
    }
}
