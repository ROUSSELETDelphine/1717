﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimatedText : MonoBehaviour
{
    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterPaused = 0.01f;
    //Message that will displays till the end that will come out letter by letter
    private string message;
    //Text for the message to display
    private Text textComp;
    public bool first;
    public GameObject second;

    // Use this for initialization
    void Start()
    {
        //Get text component
        textComp = GetComponent<Text>();
        //Message will display will be at Text
        message = textComp.text;
        //Set the text to be blank first
        textComp.text = "";
        //Call the function and expect yield to return
        StartCoroutine(TypeText());
        
    }

    IEnumerator TypeText()
    {
        //Split each char into a char array
        foreach (char letter in message.ToCharArray())
        {
            //Add 1 letter each
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
        if (first)
        {
            second.SetActive(true);
        }
        if (!first)
        {
            System.Threading.Thread.Sleep(1000);    // Thread sleeps for 1 seconds
            SceneManager.LoadScene(0);
        }
    }
}
