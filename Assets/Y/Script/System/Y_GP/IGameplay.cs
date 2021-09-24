using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y_GP
{
    public interface IGameplay
    {
        void initilaze();
        void Reload();
        void ChangeState(GPState s);
        GPResult PlayGP();

    }
}
