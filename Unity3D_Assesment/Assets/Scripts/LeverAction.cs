using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
    public MaterialList materialList;
    public GameObject[] lights;
    private Renderer lightRenderer;

    private Animator leverAnimator;
    private void Start()
    {
        leverAnimator = GetComponent<Animator>();
    }    
    public void ChangeLights()
    {
        if(lights != null)
        for(int i = 0; i < lights.Length; i++)
        {
            lightRenderer = lights[i].GetComponent<Renderer>();
            if(lightRenderer.sharedMaterial == materialList.lightMaterials[0])
            {
                lightRenderer.sharedMaterial = materialList.lightMaterials[1];
            }
            else
            {
                lightRenderer.sharedMaterial = materialList.lightMaterials[0];
            }
        }

        leverAnimator.SetTrigger("Activate");
        leverAnimator.SetFloat("Speed", -leverAnimator.GetFloat("Speed"));
    }
}
