using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.MainSystems
{
    public class VisualEventRunner : MonoBehaviour
    {
        VisualEventController visualEvent;

        private void Start()
        {
            visualEvent = VisualEventController.GetInstance();
        }

        void Update()
        {
            visualEvent.EventUpdate();
        }
    }
}
