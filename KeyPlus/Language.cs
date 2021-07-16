using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace KeyboardHook01
{
    class Language
    {

        private static Dictionary<string, string> texts = new Dictionary<string, string>();

        /// <summary>
        /// Load all the texts for UI
        /// </summary>
        public static void LoadTextByLanguage()
        {
            string languageResource;
            switch (Configure.language)
            {
                case 0:
                    languageResource = Properties.Resources.en_US;
                    break;
                case 1:
                    languageResource = Properties.Resources.zh_CN;
                    break;
                default:
                    languageResource = Properties.Resources.en_US;
                    break;
            }
            Language.texts.Clear();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(languageResource);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string key = node.Attributes["name"].Value.ToString();
                string value = node.InnerText;
                Language.texts.Add(key, value);
            }
        }

        /// <summary>
        /// Get a text by name
        /// </summary>
        /// <param name="name">Refer to the XML file</param>
        /// <returns>
        ///     Return the corresponding text. If not exist, return blank.
        ///     The text could contain \n for a new line
        /// </returns>
        public static string GetText(string name)
        {
            string res;
            try
            {
                string text = Language.texts[name];
                Regex rx = new Regex(@"\\n");
                string[] textArray = rx.Split(text);
                res = textArray[0];
                for(int i = 1; i < textArray.Length; ++i)
                {
                    res += (Environment.NewLine + textArray[i]);
                }
            }
            catch
            {
                res = "";
            }
            return res;
        }
    }
}
