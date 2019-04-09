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
        public class Publisher
        {
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

        }
    }
}
