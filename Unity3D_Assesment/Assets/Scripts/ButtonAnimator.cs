using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
    private Animator animator;

    public GameObject[] wires;
    private Renderer wireRenderer;
    public Material[] wireMaterials;

    public GameObject door = null;
    private Animator doorAnimator = null;

    bool isClosed = true;
    void Start()
    {
        animator = GetComponent<Animator>();

        if(door != null)
        {
            doorAnimator = door.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        if (animator != null)
        {
            animator.SetBool("objectOver", true);
            ChangeColor(1);


            if (door != null && isClosed)
            {
                OpenDoor();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (animator != null)
        {
            animator.SetBool("objectOver", false);
            ChangeColor(0);

            if (door != null && !isClosed)
            {
                CloseDoor();
            }
        }
    }

    private void ChangeColor(int wireColorNumber)
    {
        foreach(GameObject wire in wires)
        {
            wireRenderer = wire.GetComponent<Renderer>();
            wireRenderer.sharedMaterial = wireMaterials[wireColorNumber];
        }
    }

    private void OpenDoor()
    {
        doorAnimator.SetTrigger("OpenDoor");
        isClosed = false;
    }
    
    private void CloseDoor()
    {
        doorAnimator.SetTrigger("CloseDoor");
        isClosed = true;
    }
}
