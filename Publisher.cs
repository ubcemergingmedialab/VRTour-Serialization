using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ARDesign
{
    namespace Serialize
    {

        /// <summary>
        /// Helper functions for sending scene configurations
        /// </summary>
        public class Publisher
        {

            /// <summary>
            /// Builds a preconfigured web request for posting a given config, with an optional name
            /// </summary>
            /// <param name="name">(Optional) name for configuration</param>
            /// <param name="json">JSON string with configuration info</param>
            /// <returns></returns>
            public static UnityWebRequest SendScene(string name, string json)
            {
                string jsonToPost = name == "" ? PrepPost(json) : PrepPost(json, name);
                UnityWebRequest www = new UnityWebRequest(Utility.URL + "/scenes");

                www.method = UnityWebRequest.kHttpVerbPOST;
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonToPost);
                UploadHandler uploader = new UploadHandlerRaw(bytes);
                DownloadHandler downloader = new DownloadHandlerBuffer();
                uploader.contentType = "application/json";

                www.uploadHandler = uploader;
                www.downloadHandler = downloader;

                return www;
            }

            #region PRIVATE_METHODS
            private static string PrepPost(string json, string name_)
            {
                PostBody toReturn = new PostBody
                {
                    name = name_,
                    config = JObject.Parse(json)
                };
                return JsonConvert.SerializeObject(toReturn);
            }
            private static string PrepPost(string json)
            {
                PostBodyNoName toReturn = new PostBodyNoName
                {
                    config = JObject.Parse(json)
                };
                return JsonConvert.SerializeObject(toReturn);
            }
            private struct PostBody
            {
                public string name;
                public JObject config;
            }
            private struct PostBodyNoName
            {
                public JObject config;
            }
            #endregion //PRIVATE_METHODS
        }
    }
}
