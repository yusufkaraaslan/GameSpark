using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana.MainSystems
{
    [System.Serializable]
    public class VisualEventController : MonoBehaviour, YatanaModule
    {
        static bool IsOn = false;

        #region Singleton
        private static VisualEventController _instance;

        public VisualEventSettingData visualEventSetting;


        public static VisualEventController Instance()
        {
            if (_instance == null)
            {
                _instance = new VisualEventController();
            }

            return _instance;
        }

        public void initilaze()
        {

        }

        private VisualEventController(){ }
        #endregion

        public static List<VisualEvent> visualEvents;

        public VisualEvent AddVisualEvent(List<VisualEventData> data)
        {
            VisualEvent visualEvent = new VisualEvent(data);
            visualEvents.Add(visualEvent);
            return visualEvent;
        }

        public void ClearAllEvents()
        {
            visualEvents.Clear();
        }

        public bool IsAllEventDone()
        {
            return visualEvents.Count == 0;
        }

        private void Start()
        {
            visualEvents = new List<VisualEvent>();
        }

        private void Update()
        {
            for (int i = visualEvents.Count - 1; i >= 0; i--)
            {
                visualEvents[i].work();

                if (visualEvents[i].IsComplete())
                {
                    visualEvents.Remove(visualEvents[i]);
                }
            }
        }

        public YatanaModule GetModule()
        {
            return Instance();
        }

        public string GetModuleName()
        {
            return "Visual Event";
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
    }
}

