using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARDesign.Serialize
{
    public class VariableManager : MonoBehaviour
    {
        public static VariableManager instance = null;
        private DBScene toBuild;
        private IList<DBWidget> widgets = null;

        [SerializeField]
        private bool test = false;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
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

        public void SetBaseVals(string h, string p, string d)
        {
            toBuild.Host = h;
            toBuild.Port = p;
            toBuild.Db = d;
        }

        public void AddWidget(DBWidget wid)
        {
            if (widgets == null)
            {
                widgets = new List<DBWidget>();
            }
            widgets.Add(wid);
            toBuild.Widgets = widgets;
        }

        public new string ToString()
        {
            return Utility.BuildSceneToString(toBuild);
        }

        public void Test()
        {
            Utility.BuildSceneToFile(toBuild);
        }
    }
}



