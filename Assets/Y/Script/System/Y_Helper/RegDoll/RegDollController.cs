using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    public class RegDollController : MonoBehaviour
    {
        [SerializeField]
        Animator animator;
        [SerializeField]
        Rigidbody[] rigs;
        [SerializeField]
        Collider[] cols;
        [SerializeField]
        CharacterJoint[] joints;

        [SerializeField]
        Collider[] playerCols;

        public void RegOn()
        {
            animator.enabled = false;

            for (int i = 0; i < cols.Length; i++)
            {
                cols[i].isTrigger = false;
            }

            for (int i = 0; i < playerCols.Length; i++)
            {
                playerCols[i].isTrigger = true;
            }

            for (int i = 0; i < rigs.Length; i++)
            {
                rigs[i].isKinematic = false;
                rigs[i].detectCollisions = true;
                rigs[i].useGravity = true;
            }
        }

        public void AnimOn()
        {
            for (int i = 0; i < joints.Length; i++)
            {
                joints[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < rigs.Length; i++)
            {
                rigs[i].isKinematic = true;
                rigs[i].detectCollisions = false;
                rigs[i].useGravity = false;
            }

            for (int i = 0; i < cols.Length; i++)
            {
                cols[i].isTrigger = true;
            }

            for (int i = 0; i < playerCols.Length; i++)
            {
                playerCols[i].isTrigger = false;
            }

            animator.enabled = true;

            for (int i = 0; i < joints.Length; i++)
            {
                joints[i].gameObject.SetActive(true);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            AnimOn();
        }

    }

}