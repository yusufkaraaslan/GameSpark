using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y_GP
{
    public class LevelManeger : MonoBehaviour
    {
        GPState state;
        [SerializeField]
        GPSetup[] setups;
        int setupInd;

        GPResult res;

        public void initilaze()
        {
            state = GPState.Ready;
            setupInd = 0;

            for (int i = 0; i < setups.Length; i++)
            {
                setups[i].initilaze();
            }
        }

        public void Reload()
        {
            state = GPState.Ready;
            setupInd = 0;

            for (int i = 0; i < setups.Length; i++)
            {
                setups[i].Reload();
            }
        }

        public void ReloadCurrentSetup()
        {
            setups[setupInd].Reload();
            state = GPState.Ready;
        }

        public GPState GetState()
        {
            return state;
        }

        public void ChangeState(GPState s)
        {
            state = s;
        }

        public GPResult PlayGPLevel()
        {
            switch (state)
            {
                case GPState.Ready:
                    PreLevel();
                    break;
                case GPState.Start:
                    StartLevel();
                    break;
                case GPState.Playing:
                    PlayLevel();
                    break;
                case GPState.Complete:
                    CompleteLevel();
                    break;
                case GPState.Exit:
                    if (PostLevel())
                    {
                        return res;
                    }
                    break;
            }

            return GPResult.Playing;
        }

        /*
        * non game relative job like adds
        */
        protected virtual void PreLevel()
        {
            state = GPState.Start;
        }

        protected virtual void StartLevel()
        {
            state = GPState.Playing;
        }

        protected void PlayLevel()
        {
            res = setups[setupInd].PlayGPSetup();

            if (res != GPResult.Playing)
            {
                state = GPState.Complete;
            }
        }

        protected virtual void CompleteLevel()
        {
            if (res == GPResult.Lose)
            {
                SetupFailed();
            }
            else
            {
                if (++setupInd < setups.Length)
                {
                    state = GPState.Start;
                }
                else
                {
                    state = GPState.Exit;
                }
            }
        }

        /*
         * non game relative job like adds
         */
        protected virtual bool PostLevel()
        {
            Reload();
            return true;
        }

        void SetupFailed()
        {
            ReloadCurrentSetup();
        }

        private void Start()
        {
            initilaze();
        }

        private void Update()
        {
            PlayGPLevel();
        }

    }
}
