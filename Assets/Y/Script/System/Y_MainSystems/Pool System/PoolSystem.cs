using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana
{
    namespace MainSystems
    {
        [System.Serializable] 
        public class PoolSystem : YatanaModule
        {
            static bool IsOn = false;

            private static List<ObjPool> pools;
            private static PoolSystem poolSystem;

            public PoolSettingData poolSetting;

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("IsOn", IsOn, typeof(bool));
                info.AddValue("pools", pools, typeof(List<ObjPool>));
                info.AddValue("poolSystem", poolSystem, typeof(PoolSystem));
            }

            public PoolSystem(SerializationInfo info, StreamingContext context)
            {
                IsOn = (bool)info.GetValue("IsOn", typeof(bool));
                pools = (List<ObjPool>)info.GetValue("pools", typeof(List<ObjPool>));
                poolSystem = (PoolSystem)info.GetValue("poolSystem", typeof(PoolSystem));
            }

            public static void initilaze(GameObject[] samples)
            {
                ObjPool tmp;

                if (poolSystem == null)
                {
                    poolSystem = new PoolSystem();
                }

                pools = new List<ObjPool>();

                for (int i = 0; i < samples.Length; i++)
                {
                    tmp = new ObjPool();
                    tmp.initilaze(samples[i]);
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
            public void Reset()
            {
                Name = "Pool System";
            }
            */

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

            public string GetModuleName()
            {
                return "Pool Sys";
            }

            public void Initilaze(YatanaSystemCenter yatanaControlCenter)
            {
                throw new System.NotImplementedException();
            }

            public void SystemOn()
            {
                IsOn = true;
            }

            public void SystemOff()
            {
                IsOn = false;
            }

            public void UpdateSystem()
            {
                throw new System.NotImplementedException();
            }

            public YatanaModule GetModule()
            {
                return GetInstance();
            }

            public void InstanceInit()
            {
                throw new System.NotImplementedException();
            }

            public void AddSystem()
            {
                throw new System.NotImplementedException();
            }

            public void RemoveSystem()
            {
                throw new System.NotImplementedException();
            }

            public bool IsSystemOn()
            {
                return IsOn;
            }

            public PoolSystem()
            {
                 
            }

        }
    }

}
