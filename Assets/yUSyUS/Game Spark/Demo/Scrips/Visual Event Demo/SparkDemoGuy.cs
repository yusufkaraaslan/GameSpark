using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkDemoGuy : MonoBehaviour
{
    Vector3 respartPos;
    Quaternion resetRot;
    Animator animator;

    void Start()
    {
        respartPos = transform.position;
        resetRot = transform.rotation;
        animator = GetComponent<Animator>();
    }

    public void ResetCheracter()
    {
        animator.SetTrigger("Idle");
        transform.position = respartPos;
        transform.rotation = resetRot;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

}
