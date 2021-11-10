using System.Collections.Generic;
using UnityEngine;
using SparkGameCore.MainSystems;

namespace SparkGameCore
{
    [System.Serializable]
    public class PoolSystem : SparkGameCoreModule
    {
        private List<ObjectPool> pools;
        private static PoolSystem poolSystem;

        public PoolSettingData poolSetting;

        public void initilaze()
        {
            pools = new List<ObjectPool>();

            ObjectPool tmp;
            for (int i = 0; i < poolSetting.poolObjects.Length; i++)
            {
                tmp = new ObjectPool();
                tmp.initilaze(poolSetting.poolObjects[i].gameObject, poolSetting);
                pools.Add(tmp);
            }
        }

        public static PoolSystem GetInstance()
        {
            if (poolSystem == null)
            {
                poolSystem = new PoolSystem();
            }

            return poolSystem;
        }

        /*
         *  Using Vector3
         */
        public PoolObject GetObj(string objName,Vector3 pos, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, false, Quaternion.identity, false, Vector3.one);
            }
            else
            {
                return GetObj(objName, pos, false, Quaternion.identity, false, Vector3.one, true, setParent);
            }
        }

        public PoolObject GetObj(string objName, Vector3 pos, Quaternion rot, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, true, rot, false, Vector3.one);
            }
            else
            {
                return GetObj(objName, pos, true, rot, false, Vector3.one, true, setParent);
            }
        }
        
        public PoolObject GetObj(string objName, Vector3 pos, Vector3 scale, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, false, Quaternion.identity, true, scale);
            }
            else
            {
                return GetObj(objName, pos, false, Quaternion.identity, true, scale, true, setParent);
            }
        }

        public PoolObject GetObj(string objName, Vector3 pos, Quaternion rot, Vector3 scale, GameObject setParent = null)
        {
            if (setParent == null)
            {
                return GetObj(objName, pos, true, rot, true, scale);
            }
            else
            {
                return GetObj(objName, pos, true, rot, true, scale, true, setParent);
            }
        }

        /*
         *  Using Gameobject
         */
        public PoolObject GetObj(string objName, Transform targetObj, bool setParent = false)
        {
            return GetObj(objName, targetObj.position, false, Quaternion.identity, false, Vector3.one,
                setParent, targetObj.gameObject);
        }

        public PoolObject GetObj(string objName, Transform targetObj, bool setRot, bool setScale, bool setParent = false)
        {
            return GetObj(objName, targetObj.position, setRot, targetObj.rotation, setScale, targetObj.localScale,
                setParent, targetObj.gameObject);
        }


        public void ClearPool(string objName)
        {

            for (int i = 0; i < pools.Count; i++)
            {
                if (pools[i].poolName == objName)
                {
                    pools[i].Reload();
                }
            }
        }

        public void ClearPool()
        {
            for (int i = 0; i < pools.Count; i++)
            {
                pools[i].Reload();
            }
        }


        private PoolObject GetObj(string objName, Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale,
            bool setParrent = false, GameObject obj = null)
        {
            for (int i = 0; i < pools.Count; i++)
            {
                if (string.Compare(pools[i].poolName, objName) == 0)
                {
                    return pools[i].GetObj(pos, useRotation, rot, useScale, scale, setParrent, obj);
                }
            }

            Debug.LogError(objName + " Cant Found");
            return null;
        }


        private PoolSystem()
        {

        }

    }
}
