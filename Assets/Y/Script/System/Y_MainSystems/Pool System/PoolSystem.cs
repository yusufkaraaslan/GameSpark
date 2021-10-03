using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana.MainSystems
{
    [System.Serializable]
    public class PoolSystem : YatanaModule
    {
        private List<ObjPool> pools;
        private static PoolSystem poolSystem;

        public PoolSettingData poolSetting;

        public void initilaze()
        {
            pools = new List<ObjPool>();

            ObjPool tmp;
            for (int i = 0; i < poolSetting.poolObjects.Length; i++)
            {
                tmp = new ObjPool();
                tmp.initilaze(poolSetting.poolObjects[i].gameObject);
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

        public PoolObj GetObj(string objName, GameObject pos, bool useRotation, bool setParent = false, bool useScale = false)
        {
            return GetObj(objName, pos.transform.position, useRotation, pos.transform.rotation, useScale, pos.transform.localScale, setParent, pos);
        }

        public PoolObj GetObj(string objName, Vector2Int pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale,
            bool setParrent = false, GameObject obj = null)
        {
            return GetObj(objName, new Vector3(pos.x, pos.y), useRotation, rot, useScale, scale, setParrent, obj);
        }
        public PoolObj GetObj(string objName, Vector2 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale,
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
        public PoolObj GetObj(string objName, Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale,
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

        public void ClearPool(string objName, bool restartObj = true)
        {

            for (int i = 0; i < pools.Count; i++)
            {
                if (pools[i].poolName == objName)
                {
                    pools[i].Reload(restartObj);
                }
            }

            Debug.LogError(objName + " Cant Found");
        }

        public void ClearPool(bool restartObj = true)
        {
            for (int i = 0; i < pools.Count; i++)
            {
                pools[i].Reload(restartObj);
            }
        }

        private PoolSystem()
        {

        }

    }
}
