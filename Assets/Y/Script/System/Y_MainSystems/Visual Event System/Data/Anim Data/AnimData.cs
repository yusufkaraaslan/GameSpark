using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        [System.Serializable]
        public class AnimData
        {
            public List<AnimOrder> animOrders;

            public AnimData()
            {
                animOrders = new List<AnimOrder>();
            }

            public AnimData(AnimData animData)
            {
                animOrders = new List<AnimOrder>();

                foreach (var item in animData.animOrders)
                {
                    animOrders.Add(new AnimOrder(item));
                }
            }

            public void AddAnim(AnimOrder animOrder)
            {
                if (animOrders == null)
                {
                    animOrders = new List<AnimOrder>();
                }

                animOrders.Add(animOrder);
            }
        }
    }
}

