using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    public class ImmediateCamLayout : Layout
    {
        public GameObject camPose;
        public bool useRot;

        [SerializeField] GameObject[] closeObject;

        private void Start()
        {
            initilaze();

            for (int i = 0; i < closeObject.Length; i++)
            {
                closeObject[i].SetActive(false);
            }
        }

        public override void initilaze()
        {
            AddGameObject("camPose", camPose);
            AddBool("useRot", useRot);
        }
    }
}