using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana
{
    
    public interface YatanaModule : ISerializable 
    {
        /*
         *  !!!!!!!!!!   Important   !!!!!!!!!!!
         *  this function cant use any instance specific members
         */
        public YatanaModule GetModule();

        public void InstanceInit();

        public string GetModuleName();

        public void Initilaze(YatanaSystemCenter yatanaControlCenter);

        public void AddSystem();

        public void RemoveSystem();

        public bool IsSystemOn();

        public void SystemOn();

        public void SystemOff();

        /*
         * May Add Later (observer)
         */
        public void UpdateSystem();

    }

}
