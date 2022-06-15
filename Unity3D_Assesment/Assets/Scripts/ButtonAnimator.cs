using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        if (animator != null)
        {
            animator.SetBool("objectOver", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (animator != null)
        {
            animator.SetBool("objectOver", false);
        }
    }
}
