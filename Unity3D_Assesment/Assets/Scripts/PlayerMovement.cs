using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody objectRigidBody = null;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 forceInput = new Vector3(Input.GetAxis("Horizontal") * transform.right, 0, Input.GetAxis("Vertical"));
        Vector3 rightForceInput = Input.GetAxis("Horizontal") * transform.right * speed;
        Vector3 forwardForceInput = Input.GetAxis("Vertical") * transform.forward * speed;

        //Debug.Log(forceInput);
        objectRigidBody.AddForce(rightForceInput + forwardForceInput);
    }
}
