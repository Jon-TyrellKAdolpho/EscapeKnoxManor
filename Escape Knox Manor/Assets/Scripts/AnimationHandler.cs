using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        if(animator == null)
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }
    public void ToggleBool(string value)
    {
        animator.SetBool(value, !animator.GetBool(value));
    }
    public void SetBoolTrue(string value)
    {
        animator.SetBool(value, true);
    }
    public void SetBoolFalse(string value)
    {
        animator.SetBool(value, false);
    }
}
