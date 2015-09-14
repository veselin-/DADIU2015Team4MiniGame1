using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highscoreSave : MonoBehaviour {

    //public Text highscoreText;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //PlayerPrefs.SetInt("Best score", 0);
    }

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = ("Best score: " + PlayerPrefs.GetInt("Best score"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
