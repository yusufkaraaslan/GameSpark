using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark
{
    namespace Plus
    {
        [System.Serializable]
        public class MoveData
        {
            public List<MoveOrder> moveOrders;

            public MoveData(MoveData moveData)
            {
                moveOrders = new List<MoveOrder>();

                foreach (var item in moveData.moveOrders)
                {
                    moveOrders.Add(new MoveOrder(item));
                }
            }
            public MoveData()
            {
                moveOrders = new List<MoveOrder>();
            }

            public void AddMove(MoveOrder moveOrder)
            {
                if (moveOrders == null)
                {
                    moveOrders = new List<MoveOrder>();
                }

                moveOrders.Add(moveOrder);
            }
        }
    }
}

