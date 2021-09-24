using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y_GP
{
    public class GPSetup : MonoBehaviour
    {
        GPState state;
        [SerializeField]
        GameObject[] gpObj;
        [SerializeField]
        List<IGameplay> gameplays;
        int currGP;
        GPResult res;

        public void initilaze()
        {
            state = GPState.Ready;
            currGP = 0;
            gameplays = new List<IGameplay>();

            for (int i = 0; i < gpObj.Length; i++)
            {
                gameplays.Add(gpObj[i].GetComponent<IGameplay>());
            }

            for(int i = 0; i < gameplays.Count; ++i)
            {
                gameplays[i].initilaze();
            }
        }

        public void Reload()
        {
            state = GPState.Ready;
            currGP = 0;

            for (int i = 0; i < gameplays.Count; ++i)
            {
                gameplays[i].Reload();
            }
        }

        public GPState GetState()
        {
            return state;
        }

        public void ReloadCurrentGameplay()
        {
            gameplays[currGP].Reload();
            state = GPState.Ready;
        }

        public void ChangeState(GPState s)
        {
            state = s;
        }

        public GPResult PlayGPSetup()
        {
            switch (state)
            {
                case GPState.Ready:
                    PreSetup();
                    break;
                case GPState.Start:
                    StartSetup();
                    break;
                case GPState.Playing:
                    PlaySetup();
                    break;
                case GPState.Complete:
                    CompleteSetup();
                    break;
                case GPState.Exit:
                    if (PostSetup())
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
        protected virtual void PreSetup()
        {
            state = GPState.Start;
        }

        protected virtual void StartSetup()
        {
            state = GPState.Playing;
        }

        protected void PlaySetup()
        {
            res = gameplays[currGP].PlayGP();

            if(res != GPResult.Playing)
            {
                state = GPState.Complete;
            }
        }

        protected virtual void CompleteSetup()
        {
            if(++currGP < gameplays.Count)
            {
                state = GPState.Start;
            }
            else
            {
                state = GPState.Exit;
            }
        }

        /*
         * non game relative job like adds
         */
        protected virtual bool PostSetup()
        {
            return true;
        }

    }
}
