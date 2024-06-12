using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace KiaSolution.AppSettings
{
    public static class AppSettings
    {
        // app settings json file path:
        public static readonly string appSettingsJsonPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "kia", "2-memoryCardAppV1-consoleApp", "memoryCardAppV2-WpfApp", "WpfApp1", "AppSettings", "AppSettings.json");
        public static JObject appSettings;
        static AppSettings ()
        {
            // decode json settings:
            appSettings = JObject.Parse(File.ReadAllText(appSettingsJsonPath));
        }
        public static bool GetAppSettings (string appName, string setting)
        {
            if (appName == "FlashCardApp")
            {
                if (setting == "answerBoxDir")
                {
                    bool answerBoxDir = (bool)appSettings["FlashCardApp"]["TableManager"]["answerBoxDir"];
                    return answerBoxDir;
                } else if (setting == "questionBoxDir")
                {
                    bool questionBoxDir = (bool)appSettings["FlashCardApp"]["TableManager"]["questionBoxDir"];
                    return questionBoxDir;
                } else
                {
                    throw new Exception("no settings");
                }
            } else
            {
                throw new Exception("no appName");
            }
        }
        public static void ChangeAppSettings_qbDir ()
        {
            if ((bool)appSettings["FlashCardApp"]["TableManager"]["questionBoxDir"]) appSettings["FlashCardApp"]["TableManager"]["questionBoxDir"] = false;
            else appSettings["FlashCardApp"]["TableManager"]["questionBoxDir"] = true;
            string jsonedAppSetting = JsonConvert.SerializeObject(appSettings);
            File.WriteAllText(appSettingsJsonPath, jsonedAppSetting);
        }
        public static void ChangeAppSettings_abDir()
        {
            if ((bool)appSettings["FlashCardApp"]["TableManager"]["answerBoxDir"]) appSettings["FlashCardApp"]["TableManager"]["answerBoxDir"] = false;
            else appSettings["FlashCardApp"]["TableManager"]["answerBoxDir"] = true;
            string jsonedAppSetting = JsonConvert.SerializeObject(appSettings);
            File.WriteAllText(appSettingsJsonPath, jsonedAppSetting);
        }
    }
}
