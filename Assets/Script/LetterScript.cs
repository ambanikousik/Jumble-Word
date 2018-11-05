using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterScript : MonoBehaviour {

    int x = 0;
    string selWord;
    GameObject GameManeger;
    GameObject wordfield;

    void Start()
    {
         wordfield = GameObject.Find("WordField");    
         GameManeger = GameObject.Find("GameManager");
    }
   

    public void moveLetter(string Letter)
    {
        
        
        GameObject SelectedLetter = GameObject.Find("Char " + Letter + "(Clone)");
        selWord = GameManeger.GetComponent<InstantiateTiles>().word;
        
        if (x == 0)
        {
          
            GameManeger.GetComponent<InstantiateTiles>().word = selWord+Letter;
            GameObject obj = (GameObject)Instantiate(Resources.Load("Prefab/Charx " + Letter));
            obj.gameObject.GetComponent<LetterScript>().x = 1;
            obj.transform.SetParent(wordfield.transform, false);
        
        }
        else if (x == 1)
        {
            
                GameManeger.GetComponent<InstantiateTiles>().word = selWord.Replace(Letter, string.Empty);
          
            Destroy(this.gameObject);
        }
    
        
    }
   
}
