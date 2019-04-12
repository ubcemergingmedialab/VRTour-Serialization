using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARDesign
{
    namespace Serialize
    {

        /// <summary>
        /// Struct for storing configuration of a room - designed for deserializing from JSON
        /// </summary>
        public struct DBScene
        {
            public string Host;
            public string Port;
            public string Db;
            // List of widgets in the room
            public IList<DBWidget> Widgets;

            public string Building;
            public string Room;
        }

        /// <summary>
        /// Struct for storing widget info - Designed for JSON deserialization
        /// </summary>
        public struct DBWidget
        {
            public Vector3 Position;
            public string Measure;
            public string[] values;
        }

    }
}