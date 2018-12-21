using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class launch_game : MonoBehaviour {
    
    public VideoPlayer videoPlayer;
    public GameObject skipText;
    private bool started = false;
    private int maxIter = 120;
    private int ctr;

    private void Start()
    {
        ctr = 0;
    }

    void Update()
    {
        ctr++;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(3);
        }

        if (videoPlayer.isPlaying && !started)
        {
            started = true;
        }

        if (!videoPlayer.isPlaying && started)
        {
            SceneManager.LoadScene(3);
        }

        if(ctr == maxIter)
        {
            skipText.SetActive(false);
        }

    }

}
