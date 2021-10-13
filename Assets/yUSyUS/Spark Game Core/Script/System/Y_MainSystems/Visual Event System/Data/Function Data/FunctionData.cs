﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        [System.Serializable]
        public class FunctionData
        {
            public List<FunctionOrder> functions;

            public FunctionData()
            {
                functions = new List<FunctionOrder>();
            }

            public FunctionData(FunctionData functionData)
            {
                functions = new List<FunctionOrder>();

                foreach (FunctionOrder item in functionData.functions)
                {
                    functions.Add(item);
                }
            }

            public void AddFunction(FunctionOrder e)
            {
                if (functions == null)
                {
                    functions = new List<FunctionOrder>();
                }

                functions.Add(e);
            }
        }
    }
}
