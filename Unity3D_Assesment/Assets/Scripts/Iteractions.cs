using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iteractions : MonoBehaviour
{
    Vector3 distance;
    public Transform player;
    
    RaycastHit hit;

    bool hasItemInHands = false;

    public CheckPuzzleCompletition checkCompletition;
    
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            LiftUpItems();
            PressButton();
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.white);
            //Debug.Log("Did not Hit");
        }

        DropItems();

    }

    private void PressButton()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (hit.collider.tag == "Button")
            {
                ActivateLight activateLightScript = hit.collider.GetComponent<ActivateLight>();
                activateLightScript.TurnOnLight();
                Debug.Log("PressedLight");
            }
            if(hit.collider.tag == "ResetButton")
            {
                ResetSimonGame resetSimon = hit.collider.GetComponent<ResetSimonGame>();
                resetSimon.ResetSimon();
                Debug.Log("Pressed reset button");
            }
            if(hit.collider.tag == "Lever")
            {
                LeverAction leverActionScripit = hit.collider.GetComponent<LeverAction>();
                leverActionScripit.ChangeLights();
                checkCompletition.CheckCompletition();
                Debug.Log("Changed Lights");
            }
        }
    }

    private void DropItems()
    {
        if (hasItemInHands && Input.GetMouseButtonDown(1))
        {
            hit.transform.GetComponent<Rigidbody>().isKinematic = false;
            hit.transform.parent = null;
            hasItemInHands = false;
        }
    }

    private void LiftUpItems()
    {
        if (hit.collider.tag == "ObjectToLift" && Input.GetMouseButtonDown(0) && !hasItemInHands)
        {
            hit.transform.GetComponent<Rigidbody>().isKinematic = true;
            hit.transform.parent = transform;
            hasItemInHands = true;
        }
    }
}
