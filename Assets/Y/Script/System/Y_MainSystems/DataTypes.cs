using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DataTypes
{
}

namespace Y_Generators
{

}

namespace Yatana
{
    namespace Helper
    {
        public struct MoveResult
        {
            public MoveStatus status;
            public GameObject obj;
        }

        public enum MoveStatus
        {
            Idle, Found, Moving, MoveEnd
        }

        [System.Serializable]
        public struct layoutPoint
        {
            public Transform pos;
            public Transform followObj;
            public Vector3 offset;
            public bool useRot;
            public bool setImmediately;
            public bool follow_x;
            public bool follow_y;
            public bool follow_z;

            public float movSpeed;
            public float firstSpeed;
            public float rotSpeed;
        }

        [System.Serializable]
        class Popups
        {
            public string popupName;
            public bool isOn;
            public Text data;
            public float destroyTime;
        }
    }
}