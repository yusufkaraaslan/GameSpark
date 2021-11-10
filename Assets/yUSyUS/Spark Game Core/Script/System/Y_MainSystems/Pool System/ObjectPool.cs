using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        public class ObjectPool
        {
            public string poolName;
            GameObject waitingPos;
            List<PoolObject> objPool;
            GameObject ObjPref;

            int initSize;
            int MaxPoolSize;

            public void initilaze(GameObject sample, PoolSettingData settingData)
            {
                poolName = sample.GetComponent<PoolObject>().objName;
                objPool = new List<PoolObject>();
                ObjPref = sample;

                initSize = settingData.PoolInitilazeSize;
                MaxPoolSize = settingData.PoolMaxSize;

                waitingPos = GameObject.FindGameObjectWithTag("PoolWaiting");

                for (int i = 0; i < initSize; ++i)
                {
                    AddPool();
                }
            }

            public void Reload()
            {
                for (int i = 0; i < objPool.Count; i++)
                {
                    objPool[i].DespawnObj();
                }
            }

            public PoolObject GetObj(Transform pos, bool useRotation, bool useScale = false)
            {
                return GetObj(pos.position, useRotation, pos.rotation, useScale, pos.localScale);
            }

            public PoolObject GetObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject obj = null)
            {
                int i = 0;
                for (; i < objPool.Count; i++)
                {
                    if (objPool[i].InUse)
                    {
                        objPool[i].SpawnObj(pos, useRotation, rot, useScale, scale, setParent, obj);
                        return objPool[i];
                    }
                }

                if (IncreasePool())
                {
                    for (; i < objPool.Count; ++i)
                    {
                        if (objPool[i].InUse)
                        {
                            objPool[i].SpawnObj(pos, useRotation, rot, useScale, scale, setParent, obj);
                            return objPool[i];
                        }
                    }
                }

                return null;
            }

            void AddPool()
            {
                GameObject obj = MonoBehaviour.Instantiate(ObjPref, waitingPos.transform);
                PoolObject tmp = obj.GetComponent<PoolObject>();

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