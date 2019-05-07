using System.Collections.Generic;
using UnityEngine;
namespace VRTour
{
    namespace Serialize
    {

        /// <summary>
        /// Persistent singleton object that stores scene configuration info. 
        /// ARDesign-setup can be seen as essentially just abstracting building this
        /// </summary>
        public class VariableManager : MonoBehaviour
        {
            public static VariableManager instance = null;

            public int startNode = 0;

            #region PRIVATE_MEMBER_VARIABLES
            [SerializeField]
            private bool test = false;
            private Tour toBuild;
            private IList<Node> nodes = null;
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
                nodes = new List<Node>();
                toBuild.startPoint = nodes[startNode];

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
                    nodes = new List<Node>();
                }
                nodes.Add(n);
                toBuild.startPoint = nodes[startNode];
            }


            /// <summary>
            /// Serialize configuration into a JSON string
            /// </summary>
            /// <returns>JSON string of a deserialized tour</returns>
            public new string ToString()
            {
                return Utility.BuildSceneToString(toBuild);
            }

            /// <summary>
            /// If test is true, print finished JSON to a file
            /// </summary>
            public void Test()
            {
                Utility.BuildSceneToFile(toBuild);
            }
            #endregion //PUBLIC_METHODS
        }
    }
}


