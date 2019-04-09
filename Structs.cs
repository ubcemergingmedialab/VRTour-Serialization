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
        }

        /// <summary>
        /// Struct for storing widget info - Designed for JSON deserialization
        /// \todo Move room config out of struct
        /// \todo Add value tags to struct
        /// </summary>
        public struct DBWidget
        {

            public Vector3 Position;
            public string Measure;

            // Possibly move these to DBScene?
            public string Building;
            public string Room;
        }

    }
}