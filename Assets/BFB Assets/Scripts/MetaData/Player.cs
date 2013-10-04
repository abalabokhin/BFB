using UnityEngine;
using System.Collections;

namespace BFB.Models {
	
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
			m_sName = PlayerPrefs.GetString ("Player.Name");
			m_fCurrency = PlayerPrefs.GetFloat ("Player.Currency");
		}
		
		public void Save()
		{
			PlayerPrefs.SetString ("Player.Name", m_sName);
			PlayerPrefs.SetFloat ("Player.Currency", m_fCurrency);
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
		
		#endregion
		
		#region Fields
		
		private string m_sName;
		private float m_fCurrency;
		
		#endregion
	}
	
}