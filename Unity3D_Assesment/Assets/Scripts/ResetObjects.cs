using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjects : MonoBehaviour
{
    public Transform resetPosition = null;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = resetPosition.position;
    }
}
