using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSimonGame : MonoBehaviour
{
    public SimonSays simonSaysScript;

    public void ResetSimon()
    {
        simonSaysScript.ResetScoreLights();
        simonSaysScript.ActivateSimonSays();
    }
}
