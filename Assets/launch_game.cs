using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class launch_game : MonoBehaviour {
    
    public VideoPlayer videoPlayer;
    private bool started = false;

    void Update()
    {
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


    }

}
