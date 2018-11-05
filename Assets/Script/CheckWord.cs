using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class CheckWord : MonoBehaviour {


    public Dictionary<char, List<string>> wordsMap = new Dictionary<char, List<string>>();
    public string wordToCheck;
    GameObject GameManager;
    private List<string> allWords;
     private List<string> allWordsUnique;
    public string word;
    public string w;
    public Text ScoreText;
    public int score;
    void Awake()
        
    {
        GameManager = GameObject.Find("GameManager");
       


       string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "words.txt");
       // string filePathx = System.IO.Path.Combine(Application.streamingAssetsPath, "words.txt");

        string result = System.IO.File.ReadAllText(filePath);
      //  string resultx = System.IO.File.ReadAllText(filePathx);

        ProcessWordSource(result);
       ProcessWordData();
     //   StartCoroutine("ProcessWordData");




    }
    public string GetRandomWord(int len = 0)
    {
        if (len != 0)
        {

            while (true)
            {
                var i = Random.Range(0, allWordsUnique.Count);
                 w = allWordsUnique[i].TrimEnd();
                w = w.TrimStart();
                allWordsUnique.RemoveAt(i);
                if (w.Length == len)
                {
                    return w;
                }
            }
        }

        var index = Random.Range(0, allWordsUnique.Count);
         word = allWordsUnique[index].TrimEnd();
        word = word.TrimStart();
        allWordsUnique.RemoveAt(index);
        return word;
    }
  //  IEnumerator ProcessWordData()
  void ProcessWordData()
    {
    /*    string filePathx = System.IO.Path.Combine(Application.streamingAssetsPath, "c.txt");
        string resultx = null;

        if (filePathx.Contains("://"))
        {
            WWW www = new WWW(filePathx);
            yield return www;
            resultx = www.text;
        }
        else
            resultx = System.IO.File.ReadAllText(filePathx);
        */
        TextAsset file = Resources.Load("commonWords") as TextAsset;

        //   string data = resultx;
        string data = file.ToString();

        var words = data.Split('\n');
        allWords = new List<string>(words);

        ShuffleList(allWords);

        allWordsUnique = new List<string>();
        allWordsUnique.AddRange(allWords);
    }


    void ProcessWordSource(string data)
    {
        var words = data.Split('\n');
        foreach (var entry in words)
        {
            var c = entry[0];
            if (!wordsMap.ContainsKey(c))
            {
                wordsMap.Add(c, new List<string>());
            }
            wordsMap[c].Add(entry.TrimEnd());
        }
    }
    public bool checkWord(string word)
    {
        if (!wordsMap.ContainsKey(word[0]))
            return false;
        var list = wordsMap[word[0]];
        if (list != null)
        {
            return list.Contains(word);

        }
        return false;
    }
  public void Check()
    {
         wordToCheck = GameManager.GetComponent<InstantiateTiles>().word;
        string wordToCheckx = wordToCheck.ToLower();
        if (checkWord(wordToCheckx))
        {
            Debug.Log(wordToCheck + " is a valid word");
            GameManager.GetComponent<InstantiateTiles>().loadAgain = 1;
            float TimeLeft = GameManager.GetComponent<CountDown>().timeLeft;
            GameManager.GetComponent<CountDown>().timeLeft = TimeLeft + 20;
            score++;
            ScoreText.text = "Score:" + score;
            
            
        }
        else if (!checkWord(wordToCheckx))
        {
            Debug.Log(wordToCheck + " is NOT a valid word");

        }
    }
    private static System.Random random = new System.Random();

    public static void ShuffleList<T>(List<T> array)
    {
        int n = array.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(random.NextDouble() * (n - i));
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
}
