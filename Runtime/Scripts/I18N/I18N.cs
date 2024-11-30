#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Xml;
using System;

namespace VRChatAvatarToolkit
{
    public class I18N
    {
        private static I18N _instance;
        public static I18N Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new I18N();
                    _instance.LoadLangDict();
                }
                return _instance;
            }
        }

        private static Dictionary<string, Dictionary<string, string>> langDict;

        private I18N()
        {
            langDict = new Dictionary<string, Dictionary<string, string>>();
        }

        private void LoadLangDict()
        {
            // Read Lang File
            var langFileDir = $"Packages/{MoyuToolkitUtils.GetPackageId()}/Editor/Assets/I18N/";
            var xmlText = AssetDatabase.LoadAssetAtPath($"{langFileDir}{Application.systemLanguage}.xml", typeof(TextAsset)) as TextAsset;
            if (xmlText == null)
                xmlText = AssetDatabase.LoadAssetAtPath($"{langFileDir}English.xml", typeof(TextAsset)) as TextAsset;
            // Convert
            var xml = new XmlDocument();
            xml.LoadXml(xmlText.text);
            foreach (XmlElement pluginNode in xml.ChildNodes)
            {
                var dict = new Dictionary<string, string>();
                foreach (XmlElement langNode in pluginNode.ChildNodes)
                {
                    var key = langNode.GetAttribute("Key");
                    var value = langNode.GetAttribute("Value");
                    dict.Add(key, value);
                }
                langDict.Add(pluginNode.Name, dict);
            }
        }

        public void Reload()
        {
            langDict.Clear();
            LoadLangDict();
        }

        public static string GetText(string key, params object[] args)
        {
            var method = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod();
            var className = method.ReflectedType.Name;
            try
            {
                var text = langDict[className][key];
                for (var i = 0; i < args.Length; i++)
                    text = text.Replace($"{{{i}}}", args[i] as string);
                return text;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return $"<{className}-{key}>";
            }
        }
    }
}
#endif