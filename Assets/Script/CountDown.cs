using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour{

    public  float timeLeft ;
  
    public Text Timertext;

   

    void Update()
    {
        timeLeft -= Time.deltaTime;
        Timertext.text = "   Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            Application.LoadLevel(0);
        }
    }
}