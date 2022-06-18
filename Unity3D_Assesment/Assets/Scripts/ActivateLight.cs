using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLight : MonoBehaviour
{
    public int buttonNumber = 0;

    public GameObject buttonLight;
    private Renderer lightRenderer;

    public SimonSays simonSaysScript;
    /// <summary>
    /// The script to access the simon says list of the corect order
    /// </summary>

    private void Start()
    {
        if(buttonLight != null)
        {
            lightRenderer = buttonLight.GetComponent<Renderer>();
        }
    }
    public void TurnOnLight()
    {
        if (simonSaysScript.AddCurrentButtonToOrderAndCompare(buttonNumber))
        {
            StartCoroutine(FlickLight());
        }
    }
    /// <summary>
    /// It will flick the light on and off in a period of 2 seconds
    /// It will not allow multiple pressing
    /// </summary>
    IEnumerator FlickLight()
    {
        simonSaysScript.DisableButtons();
        Debug.Log("I will turn on the light");
        lightRenderer.sharedMaterial = simonSaysScript.lightsMaterials[1];
        Debug.Log("I will wait 1 sec");
        yield return new WaitForSeconds(1);
        Debug.Log("I will turn off the light");
        lightRenderer.sharedMaterial = simonSaysScript.lightsMaterials[0];
        //Debug.Log("I will wait 1 sec");
        //yield return new WaitForSeconds(1);
        Debug.Log("I will activate the buttons again");

        simonSaysScript.ActivateButtons();
    }
}
