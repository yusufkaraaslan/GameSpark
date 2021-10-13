using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        public class ObjPool
        {
            public string poolName;
            GameObject waitingPos;
            List<PoolObj> objPool;
            GameObject ObjPref;

            [SerializeField]
            int initSize = 10;
            [SerializeField]
            int MaxPoolSize = 500;

            public void initilaze(GameObject sample)
            {
                //Debug.Log(sample.transform.name);
                poolName = sample.GetComponent<PoolObj>().objName;
                objPool = new List<PoolObj>();
                ObjPref = sample;

                waitingPos = GameObject.FindGameObjectWithTag("PoolWaiting");

                for (int i = 0; i < initSize; ++i)
                {
                    AddPool();
                }
            }

            public void Reload(bool restartObj)
            {
                for (int i = 0; i < objPool.Count; i++)
                {
                    objPool[i].DespawnObj(restartObj);
                }
            }

            public PoolObj GetObj(Transform pos, bool useRotation, bool useScale = false)
            {
                return GetObj(pos.position, useRotation, pos.rotation, useScale, pos.localScale);
            }

            public PoolObj GetObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject obj = null)
            {
                int i = 0;
                for (; i < objPool.Count; i++)
                {
                    if (objPool[i].SpawnObj(pos, useRotation, rot, useScale, scale, setParent, obj))
                    {
                        return objPool[i];
                    }
                }

                if (IncreasePool())
                {
                    for (; i < objPool.Count; ++i)
                    {
                        if (objPool[i].SpawnObj(pos, useRotation, rot, useScale, scale, setParent, obj))
                        {
                            return objPool[i];
                        }
                    }
                }

                return null;
            }

            void AddPool()
            {
                GameObject obj = MonoBehaviour.Instantiate(ObjPref, waitingPos.transform);
                PoolObj tmp = obj.GetComponent<PoolObj>();

                tmp.initilaze();
                tmp.DespawnObj();
                objPool.Add(tmp);
            }

            bool IncreasePool()
            {
                if (objPool.Count >= MaxPoolSize)
                {
                    return false;
                }

                int newSize = objPool.Count * 2;

                if (newSize >= MaxPoolSize)
                {
                    newSize = MaxPoolSize;
                }

                for (int i = objPool.Count; i < newSize; i++)
                {
                    AddPool();
                }


                return true;
            }
        }
    }
}