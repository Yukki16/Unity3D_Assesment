using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float speed = 0.1f;
    private float yRotate;

    public Camera playerCamera = null;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * speed, 0);

        if(playerCamera != null)
        {

            yRotate -= Input.GetAxis("Mouse Y") * speed;
            yRotate = Mathf.Clamp(yRotate, -60, 70);
            playerCamera.transform.eulerAngles = new Vector3(yRotate, transform.eulerAngles.y, 0);
        }
    }
}
