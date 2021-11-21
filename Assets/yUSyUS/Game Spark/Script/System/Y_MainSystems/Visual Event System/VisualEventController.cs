using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark.MainSystems;

namespace GameSpark
{
    [System.Serializable]
    public class VisualEventController : GameSparkModule
    {
        #region Singleton
        private static VisualEventController maneger;

        public static VisualEventController GetInstance()
        {
            if (maneger == null)
            {
                maneger = new VisualEventController();
            }

            return maneger;
        }

        internal void initilaze()
        {
            visualEvents = new List<VisualEvent>();
        }

        private VisualEventController(){ }
        #endregion

        [HideInInspector] public VisualEventSettingData visualEventSetting;

        public static List<VisualEvent> visualEvents;

        public VisualEvent AddVisualEvent(List<VisualEventData> data)
        {
            VisualEvent visualEvent = new VisualEvent(data);
            visualEvents.Add(visualEvent);
            return visualEvent;
        }

        public VisualEvent AddVisualEvent(VisualEventData data)
        {
            List<VisualEventData> eData = new List<VisualEventData>();
            eData.Add(data);

            return AddVisualEvent(eData);
        }

        public VisualEventData GetVisualEventData(string eventName)
        {
            foreach (VisualEventProfile item in visualEventSetting.visualEventTemplates)
            {
                if (eventName == item.Name)
                {
                    return item.GetVisualEventData();
                }
            }

            Debug.LogError("Event : " + eventName + " , not found");

            return null;
        }

        public void ClearAllEvents()
        {
            visualEvents.Clear();
        }

        public bool IsAllEventDone()
        {
            return visualEvents.Count == 0;
        }

        internal void EventUpdate()
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
    }
}
