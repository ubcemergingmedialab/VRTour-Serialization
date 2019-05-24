using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            /// <summary>
            /// Converts an unsorted array of nodes to a dictionary, indexed by node ID. For deserializing
            /// </summary>
            /// <param name="nodeArray">Unsorted array of nodes</param>
            /// <returns>Indexed node dictionary</returns>
            public static Dictionary<int, Node> BuildDictionaryFromArray(Node[] nodeArray)
            {
                Dictionary<int, Node> toReturn = new Dictionary<int, Node>();
                foreach (Node n in nodeArray)
                {
                    toReturn.Add(n.nodeId, n);
                }
                return toReturn;
            }

            /// <summary>
            /// Converts a dictionary of nodes to an unsorted array of nodes, helper function for serializing
            /// </summary>
            /// <param name="nodeDict">Dictionary of nodes</param>
            /// <returns>Node Array containing nodeDict.values</returns>
            public static Node[] BuildArrayFromDict(IDictionary<int, Node> nodeDict)
            {
                List<Node> nodes = new List<Node>(nodeDict.Values);
                return nodes.ToArray();
            }
            #endregion //PUBLIC METHODS
        }
    }
}