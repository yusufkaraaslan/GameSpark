using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using MainSystems;
using Yatana.MainSystems;

namespace Y_GP
{
    [System.Serializable]
    public abstract class Gameplay<T> : MonoBehaviour, IGameplay where T : GPSceneSetup
    {
        [SerializeField]
        protected Layout[] layout;
        protected GPState state;
        [SerializeField]
        protected T scene;
        protected CamSystem cam;
        protected UIManeger ui;
        GPResult res;

        public virtual void initilaze()
        {
            scene.initilaze();
            cam = CamSystem.GetInstance();
            ui = UIManeger.GetInstance();

            state = GPState.Ready;
        }

        public void Reload()
        {
            scene.Reload();

            state = GPState.Ready;
        }

        public void ChangeState(GPState s)
        {
            state = s;
        }

        public GPResult PlayGP()
        {
            switch (state)
            {
                case GPState.Ready:
                    PreGP();
                    break;
                case GPState.Start:
                    StartGameplay();
                    break;
                case GPState.Playing:
                    res = Play();
                    break;
                case GPState.Complete:
                    CompleteGameplay();
                    break;
                case GPState.Exit:
                    if (PostGP())
                    {
                        return res;
                    }
                    break;
                default:
                    break;
            }

            return GPResult.Playing;
        }


        /*
         * non game relative job like adds
         */
        protected virtual void PreGP()
        {
            state = GPState.Start;
        }

        protected virtual void StartGameplay()
        {
            //camMove.CamOn(layout.CamPlayPose[0]);

            state = GPState.Playing;
        }

        protected abstract GPResult Play();

        protected virtual void CompleteGameplay()
        {
            state = GPState.Exit;
        }

        /*
         * non game relative job like adds
         */
        protected virtual bool PostGP()
        {
            return true;
        }

    }
}
