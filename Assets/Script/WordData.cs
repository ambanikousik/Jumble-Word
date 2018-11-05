using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

public class WordData : MonoBehaviour {

    GameObject GameManager;
    public string wordToCheck;
    [HideInInspector]
	public Dictionary<char, List<string>> wordsMap;
    public Text ScoreText;
    public int score;
    private List<string> allWords;
    private string[] usedWords;
	private List<string> allWordsUnique;
    public float timer;


	public string GetRandomWord (int len = 0)
	{
		if (len != 0) {
			
			while (true)
			{
				var i = Random.Range (0, allWordsUnique.Count);
				var w = allWordsUnique [i].TrimEnd ();
				w = w.TrimStart ();
				allWordsUnique.RemoveAt (i);
				if (w.Length == len) {
					return w;
				}
			}
		}
		
		var index = Random.Range (0, allWordsUnique.Count);
		var word = allWordsUnique [index].TrimEnd ();
		word = word.TrimStart ();
		allWordsUnique.RemoveAt (index);
		return word;
	}

	void Start ()
	{
        GameManager = GameObject.Find("GameManager");
        wordsMap = new Dictionary<char, List<string>> ();
		StartCoroutine ("LoadWordData");
	}
	
	IEnumerator LoadWordData() {
		
		string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "words.txt");
		
		string result = null;
		
		if (filePath.Contains("://")) {
			WWW www = new WWW(filePath);
			yield return www;
			result = www.text;
		} else
			result = System.IO.File.ReadAllText(filePath);
		
		ProcessWordSource(result);
		
		
		filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "commonWords.txt");

		result = null;
		
		if (filePath.Contains("://")) {
			WWW www = new WWW(filePath);
			yield return www;
			result = www.text;
		} else
			result = System.IO.File.ReadAllText(filePath);
		
		
		ProcessWordData (result);
        GameManager.GetComponent<InstantiateTiles>().initiateTile();

     //   game.InitGame ();
	}
	
	void ProcessWordSource (string data) {
		var words = data.Split('\n');
		foreach (var entry in words) 
		{
			var c = entry[0];
			if (!wordsMap.ContainsKey(c))
			{
				wordsMap.Add (c, new List<string>());
			}
			wordsMap[c].Add(entry.TrimEnd());
		}
	}
	
	void ProcessWordData (string data)
	{
		var words = data.Split('\n');
		allWords = new List<string> (words);
		
		ShuffleList (allWords);
		
		allWordsUnique = new List<string> ();
		allWordsUnique.AddRange (allWords);
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
        float TimeLeft = GameManager.GetComponent<CountDown>().timeLeft;
        if (checkWord(wordToCheckx))
        {
           
                Debug.Log(wordToCheck + " is a valid word");
               
                GameManager.GetComponent<InstantiateTiles>().loadAgain = 1;
                //   float TimeLeft = GameManager.GetComponent<CountDown>().timeLeft;
                GameManager.GetComponent<CountDown>().timeLeft = TimeLeft + timer;
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
