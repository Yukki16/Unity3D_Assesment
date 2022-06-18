using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubTutorial : MonoBehaviour
{
    public GameObject textBox = null;

    private void Start()
    {
        StartCoroutine(Sequence());
    }
    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Welcome player, to THE GAME.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "To move use WASD";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "To lift up objects use LEFT CLICK, and to drop them use RIGHT CLICK";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "The scope of this game is to escape, preatty simple right?";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
    }
}
