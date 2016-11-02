using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

using System.Xml;

namespace LangCSManager
{
    internal class LoadData
    {
        private List<DataModel> model;
        private Configuration config;
        internal string Language;

        internal List<DataModel> Load()
        {
            config = new Configuration();

            switch (config.ConfigDataType)
            {
                    case DataTypes.XML:
                    return LoadXml(Language);
                    case DataTypes.JSON:
                    return LoadJson();
                    case DataTypes.TXT:
                    return LoadTxt();
                default:
                    return LoadXml(Language);
            }
        }

        private List<DataModel> LoadXml(string language)
        {
            var cacheKey = "langCS_" + language;         

            
                if (HttpRuntime.Cache[cacheKey] == null)
                {
                    if (config.Path != null)
                    {
                        var xml = new XmlDocument();

                        var Path = HttpContext.Current.Server.MapPath(config.Path.Value);
                        xml.Load(Path + language + ".xml");

                        var nodelist = xml.SelectNodes("/langCS/lang");

                        foreach (XmlNode xn in nodelist)
                        {
                            model = new List<DataModel>
                        {
                            new DataModel
                            {
                                Key = xn.Attributes["id"].Value,
                                Value = xn.ChildNodes[0].InnerText
                            }
                        };

                            CreateCache(cacheKey);
                        }
                    }
                    else
                    {
                        throw new Exception(LangCsException.PathIsNull());
                    }
                }
                else
                {
                    model = (List<DataModel>)HttpRuntime.Cache[cacheKey];
                }           

            return model;
        }


        private List<DataModel> LoadJson()
        {
            return LoadXml(Language);
        }

        private List<DataModel> LoadTxt()
        {
            return LoadXml(Language);
        }

        private void CreateCache(string key)
        {
            HttpRuntime.Cache.Insert(key, model, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30));
        }
    }
}
