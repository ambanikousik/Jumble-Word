using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAnim : MonoBehaviour {
    public bool started = false;

    void Update()
    {
        if (started == false)
        {
            started = true;
            StartCoroutine(PlayMovie());
        }
    }

    public IEnumerator PlayMovie()
    {
        yield return Handheld.PlayFullScreenMovie("Splash.mp4",
                Color.black, FullScreenMovieControlMode.Hidden,
                FullScreenMovieScalingMode.AspectFit);
        Application.LoadLevel(1);
    }
}