using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using Assets.Core;
using Assets.Core.Scripts;
using UnityEngine.UI;

public class cubeDeath : MonoBehaviour {

    public bool enableControl = true;
	public AudioManager AudioMngr;

    public static bool lifeTimeHit = false;
    public static float espeed;
    public static int loseLife;
    public GameObject YourScoreText;
    public GameObject HighScoreText;



    // Use this for initialization
    void Start () {
        ScoreSystem.points = 0;
        loseLife = 3;
		AudioMngr = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enableControl) {
            if (Input.GetKey("left"))
            {
                transform.Translate(Vector3.left * Time.deltaTime * espeed);
            }
            if (Input.GetKey("right"))
            {
                transform.Translate(Vector3.right * Time.deltaTime * espeed);
            }
        }
    }

    //Restart the level when you hit an object
    void OnTriggerEnter(Collider coll)
    {
		Camera.main.GetComponent<PerlinShake> ().PlayShake ();
        loseLife -= 1;
        ScoreSystem.comboCount = 0;
        ScoreSystem.comboTimeReset();
        coll.gameObject.GetComponentInChildren<Collider>().enabled = false;
        //coll.gameObject.GetComponentInChildren<Renderer>().enabled = false;

		AudioMngr.FailPlay ();
	
        if (loseLife < 1)
        {
            if (ScoreSystem.points > PlayerPrefs.GetInt("Best score"))
            {
                PlayerPrefs.SetInt(LanguageManager.Instance.Get("Phrases/HighScore"), ScoreSystem.points);
                ScoreSystem.comboCount = 0;
                ScoreSystem.comboTimeReset();

            }
            YourScoreText.SetActive(true);
            YourScoreText.GetComponent<Text>().text = LanguageManager.Instance.Get("Phrases/Score") + ScoreSystem.points;
            HighScoreText.SetActive(true);
           
            GameObject.FindGameObjectWithTag(Constants.Tags.GameMaster).GetComponent<GameOverMaster>().GameOver();
        }
        //lifeTimeHit = true;
    }
}
