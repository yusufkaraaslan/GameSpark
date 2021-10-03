using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana.MainSystems
{
    [System.Serializable]
    public class VisualEventController : MonoBehaviour, YatanaModule
    {
        #region Singleton
        private static VisualEventController maneger;

        public VisualEventSettingData visualEventSetting;

        public static VisualEventController GetInstance()
        {
            if (maneger == null)
            {
                maneger = new VisualEventController();
            }

            return maneger;
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
    }
}
