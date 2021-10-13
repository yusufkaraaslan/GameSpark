using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        public abstract class Layout : MonoBehaviour
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            public Dictionary<string, object> GetCamData()
            {
                return data;
            }

            protected void AddFloat(string name, float f)
            {
                data.Add(name, f);
            }

            protected void AddGameObject(string name, GameObject g)
            {
                data.Add(name, g);
            }

            protected void AddVector3(string name, Vector3 v)
            {
                data.Add(name, v);
            }

            protected void AddBool(string name, bool b)
            {
                data.Add(name, b);
            }

            protected void AddQuaternion(string name, Quaternion q)
            {
                data.Add(name, q);
            }
        }
    }

}