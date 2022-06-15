using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftingItems : MonoBehaviour
{
    Vector3 distance;
    public Transform player;
    
    RaycastHit hit;

    bool hasItemInHands = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
            if (hit.collider.tag == "ObjectToLift" && Input.GetMouseButtonDown(0) && !hasItemInHands)
            {
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.parent = transform;
                hasItemInHands = true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.white);
            //Debug.Log("Did not Hit");
        }

        if(hasItemInHands && Input.GetMouseButtonDown(1))
        {
            hit.transform.GetComponent<Rigidbody>().isKinematic = false;
            hit.transform.parent = null;
            hasItemInHands = false;
        }
        
    }
}
