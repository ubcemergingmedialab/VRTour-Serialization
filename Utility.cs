using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace ARDesign
{
    namespace Serialize
    {
        // Helper utilities for JSON parsing
        public static class Utility
        {
            public const string URL = "https://ardesign-config.herokuapp.com/api";

            // Given a json string, deserializes it into a scene configuration
            public static DBScene CreateFromJSON(string json)
            {
                return JsonConvert.DeserializeObject<DBScene>(json);
            }

            public static string BuildSceneToString(DBScene toBuild)
            {
                string json = JsonConvert.SerializeObject(toBuild, Formatting.Indented);
                return json;
            }

            public static void BuildSceneToFile(DBScene toBuild)
            {
                // TODO: Improve date time formatting
                string curDate = DateTime.Now.ToOADate().ToString();
                string path = Application.streamingAssetsPath + "/JSON Output/jsonoutput-" + curDate + ".txt";
                System.IO.File.WriteAllText(path, BuildSceneToString(toBuild));
            }

        }
    }
}