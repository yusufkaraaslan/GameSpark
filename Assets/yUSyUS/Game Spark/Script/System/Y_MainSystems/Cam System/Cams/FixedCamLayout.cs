using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark.Plus;

namespace GameSpark
{
    public class FixedCamLayout : SparkCameraLayout
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