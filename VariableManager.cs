using System.Collections.Generic;
using UnityEngine;
namespace ARDesign
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

            #region PRIVATE_MEMBER_VARIABLES
            [SerializeField]
            private bool test = false;
            private DBScene toBuild;
            private IList<DBWidget> widgets = null;
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
                widgets = new List<DBWidget>();
                toBuild.Widgets = widgets;

                if (test) Test();
            }
            #endregion //UNITY_MONOBEHAVIOUR_METHODS

            #region PUBLIC_METHODS

            /// <summary>
            /// Sets the basic database values
            /// </summary>
            /// <param name="h">InfluxDB host address</param>
            /// <param name="p">InfluxDB port number</param>
            /// <param name="d">InfluxDB database name</param>
            public void SetBaseVals(string h, string p, string d)
            {
                toBuild.Host = h;
                toBuild.Port = p;
                toBuild.Db = d;
            }


            /// <summary>
            /// Add a widget to the configuration
            /// </summary>
            /// <param name="wid">Preconfigured widget object</param>
            public void AddWidget(DBWidget wid)
            {
                if (widgets == null)
                {
                    widgets = new List<DBWidget>();
                }
                widgets.Add(wid);
                toBuild.Widgets = widgets;
            }


            /// <summary>
            /// Serialize configuration into a JSON string
            /// </summary>
            /// <returns>JSON string of a deserialized DBScene</returns>
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


