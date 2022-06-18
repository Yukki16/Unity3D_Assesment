using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public string sceneNameToLoad = null;
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        LoadScene(sceneNameToLoad);
    }
}
