using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject[] buttons;
    public GameObject[] scoreLights;
    public GameObject resetButton;

    public Material[] lightsMaterials;

    private int[] correctOrder;
    private int[] currentOrderIntroduced;
    private int counter = 0;

    private int simonSaysLenght = 4;

    private Renderer objectRenderer = null;

    private bool gameWon = false;


    public CheckPuzzleCompletition completePuzzle = null;

    private void Start()
    {
        DisableButtons();
        correctOrder = new int[simonSaysLenght];
        currentOrderIntroduced = new int[simonSaysLenght];
    }
    public void ActivateSimonSays()
    {
        StartCoroutine(SimonSaysLights());
    }
    IEnumerator SimonSaysLights()
    {
        Debug.Log("Simon Active");
        counter = 0;
        DisableButtons();

        for (int i = 0; i < simonSaysLenght; i++)
        {
            int randomNumber = Random.Range(0, lights.Length);
            correctOrder[i] = randomNumber;
            objectRenderer = lights[randomNumber].GetComponent<Renderer>();
            objectRenderer.sharedMaterial = lightsMaterials[0];
            yield return new WaitForSeconds(1);
            objectRenderer.sharedMaterial = lightsMaterials[1];
            yield return new WaitForSeconds(1);
            objectRenderer.sharedMaterial = lightsMaterials[0];
        }

        ActivateButtons();
        Debug.Log("Simon Offline");
    }

    IEnumerator ResetSimon()
    {
        DisableButtons();
        Debug.Log("disabled buttons in reset");
        for(int i = 0; i < lights.Length; i++)
        {
            Debug.Log("changed lights to red");
            objectRenderer = lights[i].GetComponent<Renderer>();
            objectRenderer.sharedMaterial = lightsMaterials[2];
        }
        Debug.Log("waiting for 1 sec");
        yield return new WaitForSeconds(1);
        for (int i = 0; i < lights.Length; i++)
        {
            Debug.Log("turning off lights");
            objectRenderer = lights[i].GetComponent<Renderer>();
            objectRenderer.sharedMaterial = lightsMaterials[0];
        }
        Debug.Log("waiting for 1 sec");
        yield return new WaitForSeconds(1);
        ActivateButtons();
        Debug.Log("activated buttons & reset simon");
        StartCoroutine(SimonSaysLights());
    }

    IEnumerator ReceiveAPoint()
    {
        DisableButtons();
        if (!gameWon) 
        {
            //Debug.Log("disabled buttons in reset");
            for (int i = 0; i < lights.Length; i++)
            {
                Debug.Log("changed lights to white");
                objectRenderer = lights[i].GetComponent<Renderer>();
                objectRenderer.sharedMaterial = lightsMaterials[1];
            }
            Debug.Log("waiting for 1 sec");
            yield return new WaitForSeconds(1);
            for (int i = 0; i < lights.Length; i++)
            {
                Debug.Log("turning off lights");
                objectRenderer = lights[i].GetComponent<Renderer>();
                objectRenderer.sharedMaterial = lightsMaterials[0];
            }
            Debug.Log("waiting for 1 sec");
            yield return new WaitForSeconds(1);
            ActivateButtons();
            Debug.Log("activated buttons & reset simon");
            StartCoroutine(SimonSaysLights());
        }
        else
        {
            //Debug.Log("disabled buttons in reset");
            for (int i = 0; i < lights.Length; i++)
            {
                Debug.Log("changed lights to white");
                objectRenderer = lights[i].GetComponent<Renderer>();
                objectRenderer.sharedMaterial = lightsMaterials[1];
            }
            Debug.Log("waiting for 1 sec");
            yield return new WaitForSeconds(1);
            for (int i = 0; i < lights.Length; i++)
            {
                Debug.Log("turning off lights");
                objectRenderer = lights[i].GetComponent<Renderer>();
                objectRenderer.sharedMaterial = lightsMaterials[0];
            }
            Debug.Log("waiting for 1 sec");
            yield return new WaitForSeconds(1);
            completePuzzle.simonSays = true;
            completePuzzle.CheckCompletition();
        }
        
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }

    public void ActivateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].layer = LayerMask.NameToLayer("Default");
        }
    }

    public bool AddCurrentButtonToOrderAndCompare(int buttonNumber)
    {
        currentOrderIntroduced[counter] = buttonNumber;
        counter++;

        if (currentOrderIntroduced[counter - 1] != correctOrder[counter - 1])
        {
            Debug.Log("I reset Simon");
            StartCoroutine(ResetSimon());
            return false;
        }
        else
        {
            if (counter == 4)
            {
                ActivatePointLight();
                StartCoroutine(ReceiveAPoint());
                return false;
            }
            else
            {
                Debug.Log("I turn on the light of the button pressed");
                return true;
            }
        }
    }

    private void ActivatePointLight()
    {
        for(int i = 0; i < scoreLights.Length; i++)
        {
            objectRenderer = scoreLights[i].GetComponent<Renderer>();
            if(objectRenderer.sharedMaterial == lightsMaterials[0])
            {
                objectRenderer.sharedMaterial = lightsMaterials[1];
                gameWon = false;
                if(i == scoreLights.Length - 1)
                {
                    gameWon = true;
                }
                break;
            }
            else
            {
                gameWon = true;
            }
        }

        
    }

    public void ResetScoreLights()
    {
        for (int i = 0; i < scoreLights.Length; i++)
        {
            objectRenderer = scoreLights[i].GetComponent<Renderer>();           
            objectRenderer.sharedMaterial = lightsMaterials[0];
        }
    }
}
