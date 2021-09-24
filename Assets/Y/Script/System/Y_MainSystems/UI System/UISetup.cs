using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class UISetup : MonoBehaviour
        {
            public string UIName;
            public GameObject obj;

            [SerializeField]
            protected Animator animator;
            [SerializeField]
            protected string showClip;
            [SerializeField]
            protected string hideClip;
            [SerializeField]
            protected bool isAnimated;
            [SerializeField]
            protected bool cancelExitAnim;

            protected bool isActive;
            public virtual void OpenUI()
            {
                Enable();

                if (isAnimated)
                {
                    if (animator != null)
                    {
                        animator.Play(showClip, 0, 0);
                    }
                }
            }

            public virtual void CloseUI()
            {

                if (cancelExitAnim)
                {
                    Disable();
                    return;
                }

                if (isActive)
                {
                    isActive = false;

                    if (isAnimated)
                    {
                        if (animator != null)
                        {
                            animator.Play(hideClip, 0, 0);
                        }
                        else
                        {
                            Disable();
                        }
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