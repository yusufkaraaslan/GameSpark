using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using MainSystems;
using Yatana.Helper;

namespace Y_GP
{
    public abstract class GPSceneSetup : MonoBehaviour
    {
        public Player player;
        public GameObject playerPref;
        public GameObject playerObj;
        public PopupMessageSystem popup;

        public abstract void initilaze();
        public abstract void Reload();
    }
}