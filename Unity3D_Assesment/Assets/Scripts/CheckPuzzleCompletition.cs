using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzzleCompletition : MonoBehaviour
{
    public bool simonSays = false;
    public bool lightsLevers = false;

    public GameObject[] lightsFromLightLevers;
    private Renderer lightRenderer;
    private bool justAbool = true;

    public MaterialList materialList;

    public GameObject platformToDestroy;
    public void CheckCompletition()
    {
        for(int i = 0; i < lightsFromLightLevers.Length; i++)
        {
            lightRenderer = lightsFromLightLevers[i].GetComponent<Renderer>();
            if (lightRenderer.sharedMaterial != materialList.lightMaterials[1])
            {
                justAbool = false;
                break;
            }
            else
            {
                justAbool = true;
            }
        }

        if (justAbool)
            lightsLevers = true;

        if(simonSays && lightsLevers)
        {
            platformToDestroy.SetActive(false);
        }
    }
}
