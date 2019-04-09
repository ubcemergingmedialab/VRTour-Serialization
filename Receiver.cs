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
            public static UnityWebRequest GetFromId(string id)
            {
                return UnityWebRequest.Get(Utility.URL + "/scenes/" + id);
            }

        }


    }
}

