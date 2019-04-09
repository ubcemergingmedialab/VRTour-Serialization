using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ARDesign
{
    namespace Serialize
    {
        public static class Receiver
        {
            private const string requestUrl = Utility.URL + "/scenes/";

            public static UnityWebRequest GetFromId(string id)
            {
                return UnityWebRequest.Get(requestUrl + id);
            }

        }


    }
}

