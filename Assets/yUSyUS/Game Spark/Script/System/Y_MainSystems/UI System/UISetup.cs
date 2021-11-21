using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark
{
    namespace MainSystems
    {
        public class UISetup : MonoBehaviour
        {
            public string UIName;
            protected GameObject obj;

            protected bool isActive;

            /*
             *  Extra Options
             */
            [SerializeField]
            protected Animator animator;
            [SerializeField]
            protected string showClip;
            [SerializeField]
            protected string hideClip;

            public virtual void Initilaze()
            {
                obj = gameObject;
            }

            public virtual void OpenUI()
            {
                if (!isActive)
                {
                    Enable();

                    if (animator != null)
                    {
                        if (showClip != "")
                        {
                            animator.Play(showClip, 0, 0);
                        }
                    }
                }
            }

            public virtual void CloseUI(bool closeImm = false)
            {
                if (isActive)
                {
                    if (animator != null && hideClip != "" && !closeImm)
                    {
                        isActive = false;
                        animator.Play(hideClip, 0, 0);
                    }
                    else
                    {
                        Disable();
                    }
                }
            }

            public virtual void Disable()
            {
                isActive = false;
                obj.SetActive(false);
            }

            public virtual void Enable()
            {
                isActive = true;
                obj.SetActive(true);
            }
        }
    }

}