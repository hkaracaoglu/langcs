using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LangCSManager
{
    public class LangCS
    {
        
        /// <summary>
        /// Language translation.
        /// </summary>
        /// <param name="value">Translate content</param>
        /// <param name="language">Select language</param>
        /// <example>LangCS.Translate("HELLO_WORLD", "tr-TR")</example>
        /// <returns>string</returns>
        public static string Translate(string key, string language)
        {
            key = key.Trim();
            language = language.Trim();

            var client = new LoadData();

            client.Language = language;

            var model = client.Load().Where(m => m.Key == key).ToList();

            var value = key;

            if (model.Count > 0)
            {
                value = model[0].Value;
            }
            return value;
        }
        
    }

    
}
