using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainSystems;

namespace Y_GP
{
    public class DefultMenuGP : Gameplay<DefultMenuScene>
    {
        protected override void PreGP()
        {
            //cam.SetCam("Main",new ImmediateCam(), layout[0]);
        }

        protected override GPResult Play()
        {

            return GPResult.Playing;
        }
    }
}
