using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTour
{
    namespace Serialize
    {

        /// <summary>
        /// Struct for storing configuration of a tour space - designed for deserializing from JSON
        /// \todo - Add way of serializing environment for tour
        /// </summary>
        [System.Serializable]
        public struct Tour
        {
            public string name;
            public int startPoint; //Initial start node on the tour
            public Node[] nodes;

        }

        /// <summary>
        /// Struct for storing configuration of a tour position
        /// </summary>
        [System.Serializable]
        public struct Node
        {
            public int nodeId;
            public Vector3 position;
            public Vector3 rotation;
            public string label; //label represents the question in the choose your own adventure style tour
            public Destination[] answers;
        }

        /// <summary>
        /// Struct for storing configuration of question answers
        /// </summary>
        [System.Serializable]
        public struct Destination
        {
            public string label; //label represents the answer in the choose your own adventure style tour
            public int dest; //Node Id for the destination
        }

    }
}