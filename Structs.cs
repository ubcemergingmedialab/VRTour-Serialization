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
        public struct Tour
        {
            public string name;
            public Node startPoint; //Initial start node on the tour
        }

        /// <summary>
        /// Struct for storing configuration of a tour position - nodes are trees
        /// </summary>
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
        public struct Destination
        {
            public string label; //label represents the answer in the choose your own adventure style tour
            public Node dest; //Node Id for the destination
        }

    }
}