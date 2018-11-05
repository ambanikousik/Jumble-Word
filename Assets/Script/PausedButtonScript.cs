using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PausedButtonScript : MonoBehaviour {

   
   
    public GameObject PausedCanvas;
    public static bool Paused;
    
   

   

        public void paused()
    {
        Paused = false;
        PausedCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        PausedCanvas.SetActive(false);
        Time.timeScale = 1f; 
    }

    
}
