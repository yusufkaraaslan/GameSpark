using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Y_GP;
using Yatana.MainSystems;

namespace MainSystems
{
    public class GM : MonoBehaviour
    {
        [SerializeField]
        Player player;
        [SerializeField]
        PoolSystemAdaptor pool;
        [SerializeField]
        UIManegerAdaptor ui;
        [SerializeField]
        CamSystemAdaptor cam;

        [SerializeField]
        LevelManeger levels;


        public void initilazeGame()
        {
            if (player != null)
            {
                player.initilaze();
            }

            if (pool != null)
            {
                pool.Initialize();
            }

            if (ui != null)
            {
                ui.initilaze();
            }

            if (cam != null)
            {
                cam.initilaze();
            }

            if (levels != null)
            {
                levels.initilaze();
            }

        }

        private void Awake()
        {
            initilazeGame();
        }

    }
}
