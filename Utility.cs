﻿using Newtonsoft.Json;
using System;
using UnityEngine;
namespace VRTour
{
    namespace Serialize
    {
        /// <summary>
        /// Helper utilities for configuration serialization
        /// </summary>
        public static class Utility
        {
            //TEST URL
            public const string URL = "http://localhost:3000/api"; //TODO

            #region PUBLIC_METHODS
            /// <summary>
            /// Given a json string, deserializes it into a tour configuration
            /// </summary>
            /// <param name="json">JSON string to deserialize</param>
            /// <returns>DBScene object</returns>
            public static Tour CreateFromJSON(string json)
            {
                return JsonConvert.DeserializeObject<Tour>(json);
            }

            /// <summary>
            /// Serialize a given tour configuration into human readable JSON
            /// </summary>
            /// <param name="toBuild">Scene configuration</param>
            /// <returns>json string</returns>
            public static string BuildTourToString(Tour toBuild)
            {
                string json = JsonConvert.SerializeObject(toBuild, Formatting.Indented);
                return json;
            }

            /// <summary>
            /// For testing - serializes a configuration and writes it to a file
            /// </summary>
            /// <param name="toBuild">Tour configuration</param>
            public static void BuildTourToFile(Tour toBuild)
            {
                // TODO: Improve date time formatting
                string curDate = DateTime.Now.ToOADate().ToString();
                string path = Application.streamingAssetsPath + "/JSON Output/jsonoutput-" + curDate + ".txt";
                System.IO.File.WriteAllText(path, BuildTourToString(toBuild));
            }

            internal static void BuildSceneToFile(Tour toBuild)
            {
                throw new NotImplementedException();
            }
            #endregion //PUBLIC METHODS
        }
    }
}