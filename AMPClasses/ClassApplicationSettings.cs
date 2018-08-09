using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace AMPClasses
{
    [Serializable]
    public class ApplicationSettings
    {
        [XmlElement("ServiceList")]
        public List<ServiceItem> ServiceList { get; set; }

        [XmlElement("DontShowMeAgain")]
        public Boolean DontShowMeAgain { get; set; }

        [XmlElement("PreviousState")]
        public EnumSwitcherState PreviousState { get; set; }

        public ApplicationSettings()
        {
            ServiceList = new List<ServiceItem>();
            DontShowMeAgain = false;
        }

        public String SerializeToString()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                StringWriter textWriter = new StringWriter();

                xmlSerializer.Serialize(textWriter, this);
                return textWriter.ToString();
            }
            catch(Exception E)
            {
                String S = E.ToString();
                return String.Empty;
            }
        }

        public void DeserializeFromString(String stringData)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                using (TextReader reader = new StringReader(stringData))
                {
                    ApplicationSettings temp = (ApplicationSettings)xmlSerializer.Deserialize(reader);

                    this.ServiceList = temp.ServiceList;
                    this.DontShowMeAgain = temp.DontShowMeAgain;
                    this.PreviousState = temp.PreviousState;
                }
            }
            catch (Exception E) { String EString = E.ToString(); }
        }

        public void Load()
        {            
            String dataFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), String.Format(@"{0}.config", Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location)));

            if (File.Exists(dataFile))
            {
                try
                {
                    String serializedString = System.IO.File.ReadAllText(dataFile);
                    ////////////////////////////////////////////////////////////////////////////////
                    // IF SETTINGS SHOULD BE ENCRIPTED - ONCOMMENT THIS BLOCK
                    ////////////////////////////////////////////////////////////////////////////////
                    //Byte[] encryptedData = Convert.FromBase64String(System.IO.File.ReadAllText(dataFile));
                    //String serializedString = HPEncryptor.decryptStringFromBytes_AES(encryptedData);
                    ////////////////////////////////////////////////////////////////////////////////
                    this.DeserializeFromString(serializedString);
                }
                catch (Exception E) { String EString = E.ToString(); }
            }
        }

        public void Save()
        {
            try
            {
                String dataFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), String.Format(@"{0}.config", Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location)));

                String serializedString = this.SerializeToString();
                System.IO.File.WriteAllText(dataFile, serializedString);
                ////////////////////////////////////////////////////////////////////////////////
                // IF SETTINGS SHOULD BE ENCRIPTED - ONCOMMENT THIS BLOCK
                ////////////////////////////////////////////////////////////////////////////////
                //Byte[] encryptedData = HPEncryptor.encryptStringToBytes_AES(serializedString);
                //System.IO.File.WriteAllText(dataFile, Convert.ToBase64String(encryptedData));
                ////////////////////////////////////////////////////////////////////////////////
            }
            catch(Exception E) { String EString = E.ToString(); }
        }
    }    
}
