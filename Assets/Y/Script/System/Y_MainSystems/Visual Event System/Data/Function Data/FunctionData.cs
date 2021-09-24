using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        [System.Serializable]
        public class FunctionData
        {
            public List<FunctionOrder> functions;

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
