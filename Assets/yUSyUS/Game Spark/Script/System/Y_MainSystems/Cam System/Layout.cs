using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark
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
            if (data.ContainsKey(name))
            {
                data[name] = f;
            }
            else
            {
                data.Add(name, f);
            }
        }

        protected void AddGameObject(string name, GameObject g)
        {
            if (data.ContainsKey(name))
            {
                data[name] = g;
            }
            else
            {
                data.Add(name, g);
            }
        }

        protected void AddVector3(string name, Vector3 v)
        {
            if (data.ContainsKey(name))
            {
                data[name] = v;
            }
            else
            {
                data.Add(name, v);
            }
        }

        protected void AddBool(string name, bool b)
        {
            if (data.ContainsKey(name))
            {
                data[name] = b;
            }
            else
            {
                data.Add(name, b);
            }
        }

        protected void AddQuaternion(string name, Quaternion q)
        {
            if (data.ContainsKey(name))
            {
                data[name] = q;
            }
            else
            {
                data.Add(name, q);
            }
        }

        public virtual void initilaze()
        {

        }
    }
}