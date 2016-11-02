using System;
using System.Configuration;
using System.Web.Configuration;

namespace LangCSManager
{
    internal class Configuration
    {
        private readonly System.Configuration.Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/");
        
        public KeyValueConfigurationElement Path
        {
            get
            {
                if (rootWebConfig.AppSettings.Settings["langCSPath"] != null)
                {
                    return rootWebConfig.AppSettings.Settings["langCSPath"];
                }
                else
                {
                    throw new Exception(LangCsException.PathIsNull());
                }
                
            }
        }

        public DataTypes ConfigDataType
        {
            get
            {
                if (rootWebConfig.AppSettings.Settings["langCSDataType"] != null)
                {
                    switch (rootWebConfig.AppSettings.Settings["langCSDataType"].Value.ToUpper())
                    {
                        case "XML":
                            return DataTypes.XML;
                        case "JSON":
                            return DataTypes.JSON;
                        case "TXT":
                            return DataTypes.TXT;
                        default:
                            return DataTypes.XML;
                    }
                }
                else
                {
                    return DataTypes.XML;
                }
                
            }
        }
    }
}
