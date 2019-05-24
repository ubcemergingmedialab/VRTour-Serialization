using System.Collections.Generic;
using UnityEngine;
namespace VRTour
{
    namespace Serialize
    {

        /// <summary>
        /// Persistent singleton object that stores scene configuration info. 
        /// VRTourBuilder can be seen as essentially just abstracting building this
        /// </summary>
        public class VariableManager : MonoBehaviour
        {
            public static VariableManager instance = null;

            private IDictionary<int, Node> nodes = null;

            public int startNode = 0;

            #region PRIVATE_MEMBER_VARIABLES
            [SerializeField]
            private bool test = false;
            private Tour toBuild;
            
            #endregion //PRIVATE_MEMBER_VARIABLES

            #region UNITY_MONOBEHAVIOUR_METHODS
            private void Awake()
            {
                if (instance == null)
                {
                    instance = this;
                }
                else
                {
                    Destroy(gameObject);
                }
                DontDestroyOnLoad(this);
            }
            
            // Use this for initialization
            void Start()
            {
                nodes = new Dictionary<int, Node>();

                if (test) Test();
            }
            #endregion //UNITY_MONOBEHAVIOUR_METHODS

            #region PUBLIC_METHODS

            /// <summary>
            /// Sets the base tour values
            /// </summary>
            /// <param name="l">label for the tour</param>
            public void SetBaseVals(string l)
            {
                toBuild = new Tour();
                toBuild.name = l;
            }


            /// <summary>
            /// Add a node to the tour
            /// </summary>
            /// <param name="n">Preconfigured node</param>
            public void AddWidget(Node n)
            {
                if (nodes == null)
                {
                    nodes = new Dictionary<int, Node>();
                }
                nodes.Add(n.nodeId, n);
            }

            /// <summary>
            /// Sets the ID of the starting node
            /// </summary>
            /// <param name="id">Tour start point</param>
            public void SetStartID(int id)
            {
                startNode = id;
                toBuild.startPoint = nodes[startNode];
            }


            /// <summary>
            /// Returns the number of nodes added to the array
            /// </summary>
            /// <returns>Number of Nodes currently in the list</returns>
            public int GetNumNodes()
            {
                return nodes.Count;
            }


            /// <summary>
            /// Serialize configuration into a JSON string
            /// </summary>
            /// <returns>JSON string of a deserialized tour</returns>
            public new string ToString()
            {
                return Utility.BuildTourToString(toBuild);
            }

            /// <summary>
            /// If test is true, print finished JSON to a file
            /// </summary>
            public void Test()
            {
                Utility.BuildSceneToFile(toBuild);
            }

            public void Finalize(IDictionary<int, DestinationPanel> nodesConfig)
            {
                int start = startNode;
                Node n = nodes[start];
                n.answers = BuildDest(nodesConfig[start], nodesConfig);
                nodes[start] = n;
                toBuild.startPoint = nodes[start];
            }

            public ICollection<Node> GetNodes()
            {
                return nodes.Values;
            }

            #endregion //PUBLIC_METHODS

            private Destination[] BuildDest(DestinationPanel dp, IDictionary<int, DestinationPanel> nodesConfig)
            {
                Destination[] toReturn = new Destination[dp.answers.Count];
                for (int i = 0; i < dp.answers.Count; i++)
                {
                    Answer a = dp.answers[i];
                    Node n = nodes[a.GetID()];
                    n.answers = BuildDest(nodesConfig[a.GetID()], nodesConfig);
                    toReturn[i] = new Destination
                    {
                        label = a.GetLabel(),
                        dest = n
                    };
                }

                return toReturn;
            }
        }
    }
}


