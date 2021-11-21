using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark
{
    [System.Serializable]
    public class PoolObject : MonoBehaviour
    {
        public string objName;
        protected bool inUse;
        protected GameObject obj;

        Vector3 restartPos, restartScale;
        Quaternion restartRot;
        GameObject restartParent;

        public bool InUse { get => inUse; }

        public virtual void initilaze()
        {
            obj = gameObject;
            inUse = false;

            restartPos = obj.transform.position;
            restartRot = obj.transform.rotation;
            restartScale = obj.transform.localScale;
            restartParent = transform.parent.gameObject;
        }

        public virtual bool SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
        {
            inUse = true;
            obj.transform.position = pos;
            if (useRotation)
            {
                obj.transform.rotation = rot;
            }
            if (useScale)
            {
                obj.transform.localScale = scale;
            }

            if (setParent)
                obj.transform.SetParent(p.transform);

            obj.SetActive(true);

            return true;
        }

        public virtual void DespawnObj()
        {
            DespawnObjWork();

            if (PoolSystem.GetInstance().poolSetting.CloseObjectOnDespawn)
            {
                obj.SetActive(false);
            }
        }

        protected void DespawnObjWork()
        {
            obj.transform.position = restartPos;
            obj.transform.rotation = restartRot;
            obj.transform.localScale = restartScale;
            RestartParent();

            inUse = false;
        }

        public void RestartParent()
        {
            obj.transform.SetParent(restartParent.transform);
        }
    }
}
