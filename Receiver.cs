using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ARDesign
{
    namespace Serialize
    {

        /// <summary>
        /// Helper functions for loading a scene configuration
        /// </summary>
        public static class Receiver
        {

            /// <summary>
            /// Gats a preconfigured web request for loading a given id's config
            /// </summary>
            /// <param name="id">ID of desired config</param>
            /// <returns>UnityWebRequest pre-configured for fetching configuration from ID</returns>
            public static UnityWebRequest GetFromId(string id)
            {
                return UnityWebRequest.Get(Utility.URL + "/scenes/" + id);
            }

        }


    }
}

