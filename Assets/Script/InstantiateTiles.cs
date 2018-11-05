using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class InstantiateTiles : MonoBehaviour {

   
    public GameObject GameFiled;
    public GameObject WordField;
    private char[] Letter;
    static System.Random rd = new System.Random();
    public string word = string.Empty; 
    public string revisedline;
    public string ShuffledLine;
    public int loadAgain = 0;
    public int length;

   

    
    void Start () {
        
       
        
        GameFiled = GameObject.Find("GameField");
        WordField = GameObject.Find("WordField");
   //     initiateTile();

    }
	
	
	void Update () {
  
     if ( loadAgain == 1)
        {
            clearTiles(GameFiled);
            clearTiles(WordField);
            initiateTile();
            word = string.Empty;
        }
        
	}

  public  void initiateTile()

    {
        loadAgain = 0;
   
    if (length <= 10)
        {

            ShuffledLine = this.gameObject.GetComponent<WordData>().GetRandomWord(length);
            revisedline = new string(ShuffledLine.OrderBy(x => Guid.NewGuid()).ToArray());
            Letter = revisedline.ToCharArray();
            for (int i = 0; i < (length - 1); i++)
            {

                GameObject obj = (GameObject)Instantiate(Resources.Load("Prefab/Char " + (Letter[i])));

                obj.transform.SetParent(GameFiled.transform, false);

            }
           }
        else if (length > 10  && length <=26)
        {
            string frsthalf = this.gameObject.GetComponent<WordData>().GetRandomWord(length/2);  
            string scndhalf = this.gameObject.GetComponent<WordData>().GetRandomWord(length/2);
            ShuffledLine = frsthalf + scndhalf; 
            revisedline = new string(ShuffledLine.OrderBy(x => Guid.NewGuid()).ToArray());
            Letter = revisedline.ToCharArray();
            for (int i = 0; i <= (length-1); i++)
            {

                GameObject obj = (GameObject)Instantiate(Resources.Load("Prefab/Char " + (Letter[i])));

                obj.transform.SetParent(GameFiled.transform, false);

            }
        }
    else if (length > 26)
        {
            string frsthalf = this.gameObject.GetComponent<WordData>().GetRandomWord(length/4);
            string frsthalfx = this.gameObject.GetComponent<WordData>().GetRandomWord(length/4);
            string frsthalfxx = this.gameObject.GetComponent<WordData>().GetRandomWord(length/4);
            string scndhalf = this.gameObject.GetComponent<WordData>().GetRandomWord(length/4);
            ShuffledLine = frsthalf + scndhalf + frsthalfx + frsthalfxx;
            revisedline = new string(ShuffledLine.OrderBy(x => Guid.NewGuid()).ToArray());
            Letter = revisedline.ToCharArray();
            for (int i = 0; i <= (length - 1); i++)
            {

                GameObject obj = (GameObject)Instantiate(Resources.Load("Prefab/Char " + (Letter[i])));

                obj.transform.SetParent(GameFiled.transform, false);

            }
        }

    }

    void clearTiles(GameObject Parent)
    {
        Debug.Log(Parent.transform.childCount);
        int i = 0;
        GameObject[] allChildren = new GameObject[Parent.transform.childCount];
      

        foreach (Transform child in Parent.transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

        Debug.Log(transform.childCount);
    }
}
