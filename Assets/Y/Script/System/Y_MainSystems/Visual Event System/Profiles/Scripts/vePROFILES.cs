using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Yatana.MainSystems
{
    public class vePROFILES : MonoBehaviour
    {
        #region Singleton
        private static vePROFILES instance;
        public static vePROFILES Instance
        {
            get
            {
                return instance != null ? instance : throw new System.Exception("Visual Event Profiles instance is null");
            }
        }

        private void Awake()
        {
            instance = this;
        }
        #endregion

        [SerializeField]
        private List<VisualEventProfile> visualEventProfiles;

        [SerializeField]
        private List<ShakeEventProfile> shakeEvents;

        public ShakeEventProfile GetShakeEvent(string eventName)
        {
            foreach (ShakeEventProfile item in shakeEvents)
            {
                if (item.eventName == eventName)
                {
                    return item;
                }
            }

            throw new System.Exception(eventName + " not found");
        }

        public VisualEventProfile GetProfile(int index)
        {
            VisualEventProfile vep = visualEventProfiles[index];
            return vep != null ? vep : throw new System.Exception("There is no visual event profile at index : " + index);
        }
        public VisualEventProfile GetProfile(string name)
        {
            /*
            VisualEventProfile vep = visualEventProfiles.Find(s => s.name == name);
            return vep != null ? vep : throw new System.Exception("There is no visual event profile named as : " + name);
            */
            return null;
        }
        public MoveData GetMoveData(int profileIndex, int dataIndex)
        {
            MoveData moveData = new MoveData(visualEventProfiles[profileIndex].MoveData[dataIndex]);
            return moveData != null ? moveData : throw new System.Exception(); 
        }
        public MoveData GetMoveData(string profileName, int dataIndex)
        {
            /*
            MoveData moveData = visualEventProfiles.Find(s => s.name == profileName).MoveData[dataIndex];
            moveData = new MoveData(moveData);  // Sorrr 
            return moveData != null ? moveData : throw new System.Exception();
            */
            return null;
        }
        public AnimData GetAnimData(int profileIndex, int dataIndex)
        {
            AnimData animData = visualEventProfiles[profileIndex].AnimData[dataIndex];
            return animData != null ? animData : throw new System.Exception();
        }
        public AnimData GetAnimData(string profileName, int dataIndex)
        {
            /*
             *  Change New System
            AnimData animData = visualEventProfiles.Find(s => s.name == profileName).AnimData[dataIndex];
            animData = new AnimData(animData);
            return animData != null ? animData : throw new System.Exception();
            */

            return null;
        }

        public MoveOrder GetMoveOrder(int profileIndex, int dataIndex, int orderIndex)
        {
            MoveOrder moveOrder = visualEventProfiles[profileIndex].MoveData[dataIndex].moveOrders[orderIndex];
            return moveOrder != null ? moveOrder : throw new System.Exception();
        }
        public MoveOrder GetMoveOrder(string profileName, int dataIndex, int orderIndex)
        {
            /*
            MoveOrder moveOrder = visualEventProfiles.Find(s => s.name == profileName).MoveData[dataIndex].moveOrders[orderIndex];
            return moveOrder != null ? moveOrder : throw new System.Exception();
            */
            return null;
        }
        public AnimOrder GetAnimOrder(int profileIndex, int dataIndex, int orderIndex)
        {
            AnimOrder animOrder = visualEventProfiles[profileIndex].AnimData[dataIndex].animOrders[orderIndex];

            return animOrder != null ? animOrder : throw new System.Exception();
        }
        public AnimOrder GetAnimOrder(string profileName, int dataIndex, int orderIndex)
        {
            /*
            AnimOrder animOrder = visualEventProfiles.Find(s => s.name == profileName).AnimData[dataIndex].animOrders[orderIndex];
            return animOrder != null ? animOrder : throw new System.Exception();
            */
            return null;
        }
    }

}
