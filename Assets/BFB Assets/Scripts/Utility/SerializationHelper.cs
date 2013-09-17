using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFB.Helpers
{
    public static class SerializationHelper
    {
        public static T LoadXMLDataFromFile<T>(string sRelativePath, T oDefaultValue)
        {
            string sFileName = Path.Combine(Application.dataPath, sRelativePath);
            T oData = oDefaultValue;
            try
            {
                using (StreamReader oReader = new StreamReader(sFileName))
                {
                    XmlSerializer oSrlz = new XmlSerializer(typeof(T));
                    oData = (T)oSrlz.Deserialize(oReader);
                }
            }
            catch (Exception oExc)
            {
                Debug.LogError(string.Format("Error: Could not read file {0}.\n{1}", sFileName, oExc));
                throw oExc;
            }
            return oData;
        }

        public static void SaveXMLDataToFile<T>(T oData, string sRelativePath)
        {
            string sFileName = Path.Combine(Application.dataPath, sRelativePath);
            try
            {
                using (StreamWriter oWriter = new StreamWriter(sFileName, false))
                {
                    XmlSerializer oSrlz = new XmlSerializer(typeof(T));
                    oSrlz.Serialize(oWriter, oData);
                }
            }
            catch (Exception oExc)
            {
                Debug.LogError(string.Format("Error: Could not write to file {0}.\n{1}", sFileName, oExc));
                throw oExc;
            }
        }
    }

    [XmlRoot(ElementName = "Data", IsNullable = true)]
    public class XMLCollection<T>
    {
        public XMLCollection() { Collection = new List<T>(); }

        public List<T> Collection { get; set; }
    }
}

